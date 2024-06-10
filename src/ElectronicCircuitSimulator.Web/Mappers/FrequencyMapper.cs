using ElectronicCircuitSimulator.Core.Models;
using ElectronicCircuitSimulator.Web.ViewModels;

namespace ElectronicCircuitSimulator.Web.Mappers;

public class FrequencyMapper
{
    public Frequency Map(FrequencyViewModel model)
    {
        return new Frequency(
            model.Value!.Value,
            model.Unit
        );
    }

    public Frequency Map(FrequencyViewModel model, Frequency frequency)
    {
        frequency.Value = model.Value!.Value;
        frequency.Unit = model.Unit;
        return frequency;
    }
}
