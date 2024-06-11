using ElectronicCircuitSimulator.Core.Constants;
using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;
using ElectronicCircuitSimulator.Core.Models;

namespace ElectronicCircuitSimulator.Core.Services;

public class ElectricCircuitCalculator : IElectricCircuitCalculator
{
    private readonly IFaradUnitConverter _faradUnitConverter;
    private readonly IOhmUnitConverter _ohmUnitConverter;
    private readonly IVoltUnitConverter _voltUnitConverter;

    public ElectricCircuitCalculator(
        IFaradUnitConverter faradUnitConverter,
        IOhmUnitConverter ohmUnitConverter,
        IVoltUnitConverter voltUnitConverter)
    {
        _faradUnitConverter = faradUnitConverter;
        _ohmUnitConverter = ohmUnitConverter;
        _voltUnitConverter = voltUnitConverter;
    }

    public CalculateForCircuitsResponse Calculate(CalculateRequest calculateRequest)
    {
        var resistance_g = _ohmUnitConverter.Convert(calculateRequest.Resistance_g.Value, calculateRequest.Resistance_g.Unit, OhmUnit.Ohm);
        var resistance_a = _ohmUnitConverter.Convert(calculateRequest.Resistance_a.Value, calculateRequest.Resistance_a.Unit, OhmUnit.Ohm);
        var resistance_b = _ohmUnitConverter.Convert(calculateRequest.Resistance_b.Value, calculateRequest.Resistance_b.Unit, OhmUnit.Ohm);
        var resistance_E = _ohmUnitConverter.Convert(calculateRequest.Resistance_E.Value, calculateRequest.Resistance_E.Unit, OhmUnit.Ohm);
        var resistance_y = _ohmUnitConverter.Convert(calculateRequest.Resistance_y.Value, calculateRequest.Resistance_y.Unit, OhmUnit.Ohm);
        var capacitance_1 = _faradUnitConverter.Convert(calculateRequest.Capacitance_1.Value, calculateRequest.Capacitance_1.Unit, FaradUnit.Farad);
        var capacitance_2 = _faradUnitConverter.Convert(calculateRequest.Capacitance_2.Value, calculateRequest.Capacitance_2.Unit, FaradUnit.Farad);
        var voltage_CC = _voltUnitConverter.Convert(calculateRequest.Voltage_CC.Value, calculateRequest.Voltage_CC.Unit, VoltUnit.Volt);
        var voltage_BE = _voltUnitConverter.Convert(calculateRequest.Voltage_BE.Value, calculateRequest.Voltage_BE.Unit, VoltUnit.Volt);
        var beta_0 = calculateRequest.Beta_0;

        var resistance_B = Get_Resistance_B(resistance_a, resistance_b);
        var voltage_B = Get_Voltage_B(voltage_CC, resistance_a, resistance_b);
        var current_B = Get_Current_B(voltage_B, resistance_B, voltage_BE, beta_0, resistance_E);
        var current_C = Get_Current_C(current_B, beta_0);
        var current_E = Get_Current_E(current_B, current_C);
        var voltage_CE = Get_Voltage_CE(voltage_CC, resistance_E, current_E);
        var voltage_CB = Get_Voltage_CB(voltage_CE, voltage_BE);
        var operationRegion = Get_Operation_Region(voltage_BE, voltage_CB, voltage_CE, voltage_CC);
        var gm = Get_gm(current_C);
        var r_pi = Get_r_pi(beta_0, gm);

        var resistance_0 = Get_Resistance_0(resistance_E, resistance_g, resistance_B, beta_0, r_pi);
        var resistance_1 = Get_Resistance_1(resistance_g, resistance_B, r_pi, beta_0, resistance_E, resistance_y);
        var resistance_2 = Get_Resistance_2(resistance_0, resistance_y);
        var frequency_C1 = Get_Frequency_C1(resistance_1, capacitance_1);
        var frequency_C2 = Get_Frequency_C2(resistance_2, capacitance_2);
        var frequency_L = Get_Frequency_L(frequency_C1, frequency_C2);
        var k_vi = Get_K_Vi(resistance_E, resistance_y, beta_0, r_pi);
        var voltage_Gain = Get_Voltage_Gain(k_vi);

        var calculateForDirectCurrentCircuitResponse = new CalculateForDirectCurrentCircuitResponse()
        {
            Current_B = new Current(current_B, AmperUnit.Amper),
            Current_C = new Current(current_C, AmperUnit.Amper),
            Current_E = new Current(current_E, AmperUnit.Amper),
            Voltage_CE = new Voltage(voltage_CE, VoltUnit.Volt),
            Voltage_CB = new Voltage(voltage_CB, VoltUnit.Volt),
            Voltage_BE = new Voltage(voltage_BE, VoltUnit.Volt),
            Voltage_B = new Voltage(voltage_B, VoltUnit.Volt),
            OperationRegion = operationRegion
        };

        var calculateForLowFrequencyEquivalentCircuitResponse = new CalculateForLowFrequencyEquivalentCircuitResponse()
        {
            Frequency_C1 = new Frequency(frequency_C1, HertzUnit.Hertz),
            Frequency_C2 = new Frequency(frequency_C2, HertzUnit.Hertz),
            Frequency_L = new Frequency(frequency_L, HertzUnit.Hertz),
            VoltageGain = voltage_Gain,
            GMV_Pi = k_vi,
            Resistance_Pi = new Resistance(r_pi, OhmUnit.Ohm),
            Resistance_B = new Resistance(resistance_B, OhmUnit.Ohm)
        };

        return new CalculateForCircuitsResponse()
        {
            CalculateForDirectCurrentCircuitResponse = calculateForDirectCurrentCircuitResponse,
            CalculateForLowFrequencyEquivalentCircuitResponse = calculateForLowFrequencyEquivalentCircuitResponse
        };
    }

    private double Get_Resistance_B(double resistance_a, double resistance_b)
    {
        return resistance_a * resistance_b / (resistance_a + resistance_b);
    }

    private double Get_Voltage_B(double voltage_CC, double resistance_a, double resistance_b)
    {
        return resistance_b / (resistance_a + resistance_b) * voltage_CC;
    }

    private double Get_Current_B(double voltage_B, double resistance_B, double voltage_BE, double beta_0, double resistance_E)
    {
        return (voltage_B - voltage_BE) / (resistance_B + (1 + beta_0) * resistance_E);
    }

    private double Get_Current_C(double current_B, double beta_0)
    {
        return current_B * beta_0;
    }

    private double Get_Current_E(double current_B, double current_C)
    {
        return current_B + current_C;
    }

    private double Get_Voltage_CE(double voltage_CC, double resistance_E, double current_E)
    {
        return voltage_CC - (resistance_E * current_E);
    }

    private double Get_Voltage_CB(double voltage_CE, double voltage_BE)
    {
        return voltage_CE - voltage_BE;
    }

    private OperationRegion Get_Operation_Region(double voltage_BE, double voltage_CB, double voltage_CE, double voltage_CC)
    {
        if (voltage_BE > 0 && voltage_CB > 0)
        {
            return OperationRegion.Active;
        }
        else if (voltage_BE > 0 && voltage_CB < 0)
        {
            return OperationRegion.Saturation;
        }
        else if ((voltage_CE + voltage_CC) is >= -1 and <= 1)
        {
            return OperationRegion.CutOff;
        }

        throw new InvalidOperationException(
            string.Format("Invalid values. Voltage_BE = {0} - Voltage_CB = {1} - Voltage_CE= {2} - Voltage_CC = {3}", voltage_BE, voltage_CB, voltage_CE, voltage_CC));
    }

    private double Get_gm(double current_C)
    {
        return DefaultConstants.TransconductanceDefaultValue * Math.Abs(current_C);
    }

    private double Get_r_pi(double beta_0, double gm)
    {
        return beta_0 / gm;
    }

    private double Get_Resistance_0(double resistance_E, double resistance_g, double resistance_B, double beta_0, double r_pi)
    {
        return resistance_E * ((resistance_g * resistance_B / (resistance_g + resistance_B)) + r_pi) / (1 + beta_0) /
            (resistance_E + (((resistance_g * resistance_B / (resistance_g + resistance_B)) + r_pi) / (1 + beta_0)));
    }

    private double Get_Resistance_1(double resistance_g, double resistance_B, double r_pi, double beta_0, double resistance_E, double resistance_y)
    {
        return resistance_g + (
            resistance_B * (r_pi + (1 + beta_0) * (resistance_E * resistance_y / (resistance_E + resistance_y))) /
            (resistance_B + r_pi + (1 + beta_0) * (resistance_E * resistance_y / (resistance_E + resistance_y)))
        );
    }

    private double Get_Resistance_2(double resistance_0, double resistance_y)
    {
        return resistance_0 + resistance_y;
    }

    private double Get_Frequency_C1(double resistance_1, double capacitance_1)
    {
        return 1 / (2 * Math.PI * resistance_1 * capacitance_1);
    }

    private double Get_Frequency_C2(double resistance_2, double capacitance_2)
    {
        return 1 / (2 * Math.PI * resistance_2 * capacitance_2);
    }

    private double Get_Frequency_L(double frequency_C1, double frequency_C2)
    {
        if (frequency_C1 > frequency_C2)
        {
            return frequency_C1;
        }
        return frequency_C2;
    }

    private double Get_K_Vi(double resistance_E, double resistance_y, double beta_0, double r_pi)
    {
        return resistance_E * resistance_y / (resistance_E + resistance_y) * (1 + beta_0) /
            (r_pi + (resistance_E * resistance_y / (resistance_E + resistance_y) * (1 + beta_0)));
    }

    private double Get_Voltage_Gain(double k_vi)
    {
        return 20 * Math.Log10(Math.Abs(k_vi / Math.Sqrt(2)));
    }
}
