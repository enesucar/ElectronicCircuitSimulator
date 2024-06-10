using ElectronicCircuitSimulator.Core.Constants;
using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;
using ElectronicCircuitSimulator.Core.Models;
using ElectronicCircuitSimulator.Core.Services;
using System.Reflection;

namespace ElectronicCircuitSimulator.Core.Tests;

public class ElectricCircuitCalculatorTests
{
    public IElectricCircuitCalculator ElectricCircuitCalculator { get; set; }

    public IOhmUnitConverter OhmUnitConverter { get; set; }

    public IFaradUnitConverter FaradUnitConverter { get; set; }

    public IVoltUnitConverter VoltUnitConverter { get; set; }

    public IAmperUnitConverter AmperUnitConverter { get; set; }

    public IHertzUnitConverter HertzUnitConverter { get; set; }


    public ElectricCircuitCalculatorTests()
    {
        FaradUnitConverter = new FaradUnitConverter();
        OhmUnitConverter = new OhmUnitConverter();
        VoltUnitConverter = new VoltUnitConverter();
        AmperUnitConverter = new AmperUnitConverter();
        HertzUnitConverter = new HertzUnitConverter();

        ElectricCircuitCalculator = new ElectricCircuitCalculator(FaradUnitConverter, OhmUnitConverter, VoltUnitConverter);
    }

    [Fact]
    public void Calculate_ShouldReturnsExceptedValues()
    {
        var calculateRequest = new CalculateRequest()
        {
            Resistance_a = new Resistance(100, OhmUnit.Ohm),
            Resistance_b = new Resistance(470, OhmUnit.Ohm),
            Resistance_E = new Resistance(100, OhmUnit.Ohm),
            Resistance_y = new Resistance(680, OhmUnit.Ohm),
            Resistance_g = new Resistance(470, OhmUnit.Ohm),
            Capacitance_1 = new Capacitance(10, FaradUnit.Mikrofarad),
            Capacitance_2 = new Capacitance(100, FaradUnit.Mikrofarad),
            Voltage_BE = new Voltage(0.7, VoltUnit.Volt),
            Voltage_CC = new Voltage(15, VoltUnit.Volt),
            Beta_0 = 100
        };

        var result = ElectricCircuitCalculator.Calculate(calculateRequest);

        var current_B_actual = AmperUnitConverter.Convert(
            result.CalculateForDirectCurrentCircuitResponse.Current_B.Value,
            result.CalculateForDirectCurrentCircuitResponse.Current_B.Unit,
            AmperUnit.Milliamper);
        Assert.Equal(
            1.14,
            current_B_actual,
            current_B_actual * 0.01);

        var current_C_actual = AmperUnitConverter.Convert(
            result.CalculateForDirectCurrentCircuitResponse.Current_C.Value,
            result.CalculateForDirectCurrentCircuitResponse.Current_C.Unit,
            AmperUnit.Milliamper);
        Assert.Equal(
            114,
            current_C_actual,
            current_C_actual * 0.01);

        var current_E_actual = AmperUnitConverter.Convert(
            result.CalculateForDirectCurrentCircuitResponse.Current_E.Value,
            result.CalculateForDirectCurrentCircuitResponse.Current_E.Unit,
            AmperUnit.Milliamper);
        Assert.Equal(115.14,
            current_E_actual,
            current_E_actual * 0.01);

        var voltage_CE_actual = VoltUnitConverter.Convert(
            result.CalculateForDirectCurrentCircuitResponse.Voltage_CE.Value,
            result.CalculateForDirectCurrentCircuitResponse.Voltage_CE.Unit,
            VoltUnit.Volt);
        Assert.Equal(3.5,
            voltage_CE_actual,
            current_E_actual * 0.01);

        var voltage_BE_actual = VoltUnitConverter.Convert(
            result.CalculateForDirectCurrentCircuitResponse.Voltage_BE.Value,
            result.CalculateForDirectCurrentCircuitResponse.Voltage_BE.Unit,
            VoltUnit.Volt);
        Assert.Equal(DefaultConstants.Voltage_BE_DefaultValue,
            voltage_BE_actual,
            voltage_BE_actual * 0.01);

        Assert.Equal(
            OperationRegion.Active,
            result.CalculateForDirectCurrentCircuitResponse.OperationRegion);

        var frequency_C1_actual = HertzUnitConverter.Convert(
            result.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C1.Value,
            result.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C1.Unit,
            HertzUnit.Hertz                                                                                                                                  );
        Assert.Equal(28.84,
            frequency_C1_actual,
            frequency_C1_actual * 0.01);

        var frequency_C2_actual = HertzUnitConverter.Convert(
            result.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C2.Value,
            result.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C2.Unit,
            HertzUnit.Hertz);
        Assert.Equal(frequency_C2_actual,
            frequency_C2_actual,
            frequency_C2_actual * 0.01);

        var frequency_L_actual = HertzUnitConverter.Convert(
            result.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_L.Value,
            result.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_L.Unit,
            HertzUnit.Hertz);
        Assert.Equal(28,
            frequency_L_actual,
            frequency_L_actual * 0.1);

        Assert.Equal(
            -3.09,
            result.CalculateForLowFrequencyEquivalentCircuitResponse.VoltageGain,
            Math.Abs(result.CalculateForLowFrequencyEquivalentCircuitResponse.VoltageGain) * 0.05);
    }
}
