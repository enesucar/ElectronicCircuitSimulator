using ElectronicCircuitSimulator.Core.Models;
using ElectronicCircuitSimulator.Web.ViewModels;

namespace ElectronicCircuitSimulator.Web.Mappers;

public class VoltageMapper
{
    public Voltage Map(VoltageViewModel model)
    {
        return new Voltage(
            model.Value!.Value,
            model.Unit
        );
    }

    public Voltage Map(VoltageViewModel model, Voltage voltage)
    {
        voltage.Value = model.Value!.Value;
        voltage.Unit = model.Unit;
        return voltage;
    }
}
