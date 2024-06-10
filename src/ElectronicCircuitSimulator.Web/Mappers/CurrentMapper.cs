using ElectronicCircuitSimulator.Core.Models;
using ElectronicCircuitSimulator.Web.ViewModels;

namespace ElectronicCircuitSimulator.Web.Mappers;

public class CurrentMapper
{
    public Current Map(CurrentViewModel model)
    {
        return new Current(
            model.Value!.Value,
            model.Unit
        );
    }

    public Current Map(CurrentViewModel model, Current current)
    {
        current.Value = model.Value!.Value;
        current.Unit = model.Unit;
        return current;
    }
}
