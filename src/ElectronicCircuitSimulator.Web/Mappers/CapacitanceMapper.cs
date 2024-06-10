using ElectronicCircuitSimulator.Core.Models;
using ElectronicCircuitSimulator.Web.ViewModels;

namespace ElectronicCircuitSimulator.Web.Mappers;

public class CapacitanceMapper
{
    public Capacitance Map(CapacitanceViewModel model)
    {
        return new Capacitance(
            model.Value!.Value,
            model.Unit
        );
    }

    public Capacitance Map(CapacitanceViewModel model, Capacitance capacitance)
    {
        capacitance.Value = model.Value!.Value;
        capacitance.Unit = model.Unit;
        return capacitance;
    }
}
