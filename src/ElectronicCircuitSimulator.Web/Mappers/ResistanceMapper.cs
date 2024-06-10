using ElectronicCircuitSimulator.Core.Models;
using ElectronicCircuitSimulator.Web.ViewModels;

namespace ElectronicCircuitSimulator.Web.Mappers;

public class ResistanceMapper
{
    public Resistance Map(ResistanceViewModel model)
    {
        return new Resistance(
            model.Value!.Value,
            model.Unit
        );
    }

    public Resistance Map(ResistanceViewModel model, Resistance resistance)
    {
        resistance.Value = model.Value!.Value;
        resistance.Unit = model.Unit;
        return resistance;
    }
}
