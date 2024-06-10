using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;
using ElectronicCircuitSimulator.Core.Models;
using ElectronicCircuitSimulator.Web.ViewModels;

namespace ElectronicCircuitSimulator.Web.Mappers;

public class CalculateForCircuitsMapper
{
    private readonly IHertzUnitConverter _hertzUnitConverter;
    private readonly IVoltUnitConverter _voltUnitConverter;
    private readonly IAmperUnitConverter _amperUnitConverter;
    private readonly IOhmUnitConverter _ohmUnitConverter;

    public CalculateForCircuitsMapper(
        IHertzUnitConverter hertzUnitConverter,
        IVoltUnitConverter voltUnitConverter,
        IAmperUnitConverter amperUnitConverter,
        IOhmUnitConverter ohmUnitConverter)
    {
        _hertzUnitConverter = hertzUnitConverter;
        _voltUnitConverter = voltUnitConverter;
        _amperUnitConverter = amperUnitConverter;
        _ohmUnitConverter = ohmUnitConverter;
    }

    public CalculateRequest Map(CalculateViewModel model)
    {
        var request = new CalculateRequest();
        request.Resistance_g = new Resistance(model.Resistance_g.Value!.Value, model.Resistance_g.Unit);
        request.Resistance_a = new Resistance(model.Resistance_a.Value!.Value, model.Resistance_a.Unit);
        request.Resistance_b = new Resistance(model.Resistance_b.Value!.Value, model.Resistance_b.Unit);
        request.Resistance_E = new Resistance(model.Resistance_E.Value!.Value, model.Resistance_E.Unit);
        request.Resistance_y = new Resistance(model.Resistance_y.Value!.Value, model.Resistance_y.Unit);
        request.Capacitance_1 = new Capacitance(model.Capacitance_1.Value!.Value, model.Capacitance_1.Unit);
        request.Capacitance_2 = new Capacitance(model.Capacitance_2.Value!.Value, model.Capacitance_2.Unit);
        request.Voltage_CC = new Voltage(model.Voltage_CC.Value!.Value, model.Voltage_CC.Unit);
        request.Voltage_BE = new Voltage(model.Voltage_BE.Value!.Value, model.Voltage_BE.Unit);
        request.Beta_0 = model.Beta_0;
        return request;
    }

    public CalculateViewModel Map(CalculateForCircuitsResponse response, CalculateViewModel model)
    {
        model.Current_B.Value = _amperUnitConverter.Convert(
            response.CalculateForDirectCurrentCircuitResponse.Current_B.Value,
            response.CalculateForDirectCurrentCircuitResponse.Current_B.Unit,
            model.Current_B.Unit);

        model.Current_C.Value = _amperUnitConverter.Convert(
            response.CalculateForDirectCurrentCircuitResponse.Current_C.Value,
            response.CalculateForDirectCurrentCircuitResponse.Current_C.Unit,
            model.Current_C.Unit);

        model.Current_E.Value = _amperUnitConverter.Convert(
            response.CalculateForDirectCurrentCircuitResponse.Current_E.Value,
            response.CalculateForDirectCurrentCircuitResponse.Current_E.Unit,
            model.Current_E.Unit);

        model.Voltage_CE.Value = _voltUnitConverter.Convert(
            response.CalculateForDirectCurrentCircuitResponse.Voltage_CE.Value,
            response.CalculateForDirectCurrentCircuitResponse.Voltage_CE.Unit,
            model.Voltage_CE.Unit);

        model.Voltage_CB.Value = _voltUnitConverter.Convert(
            response.CalculateForDirectCurrentCircuitResponse.Voltage_CB.Value,
            response.CalculateForDirectCurrentCircuitResponse.Voltage_CB.Unit,
            model.Voltage_CB.Unit);

        model.Voltage_B.Value = _voltUnitConverter.Convert(
            response.CalculateForDirectCurrentCircuitResponse.Voltage_B.Value,
            response.CalculateForDirectCurrentCircuitResponse.Voltage_B.Unit,
            model.Voltage_B.Unit);

        model.OperationRegion = response.CalculateForDirectCurrentCircuitResponse.OperationRegion;

        model.Frequency_C1.Value = _hertzUnitConverter.Convert(
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C1.Value,
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C1.Unit,
            model.Frequency_C1.Unit);

        model.Frequency_C2.Value = _hertzUnitConverter.Convert(
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C2.Value,
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_C2.Unit,
            model.Frequency_C2.Unit);

        model.Frequency_L.Value = _hertzUnitConverter.Convert(
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_L.Value,
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Frequency_L.Unit,
            model.Frequency_L.Unit);

        model.VoltageGain = response.CalculateForLowFrequencyEquivalentCircuitResponse.VoltageGain;

        model.Resistance_Pi.Value = _ohmUnitConverter.Convert(
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Resistance_Pi.Value,
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Resistance_Pi.Unit,
            model.Resistance_Pi.Unit);

        model.GMV_Pi = response.CalculateForLowFrequencyEquivalentCircuitResponse.GMV_Pi;

        model.Resistance_B.Value = _ohmUnitConverter.Convert(
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Resistance_B.Value,
            response.CalculateForLowFrequencyEquivalentCircuitResponse.Resistance_B.Unit,
            model.Resistance_B.Unit);

        return model;
    }
}
