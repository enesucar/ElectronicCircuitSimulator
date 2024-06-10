using ElectronicCircuitSimulator.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ElectronicCircuitSimulator.Web.ViewModels;

public class ResistanceViewModel
{
    [Required]
    public double? Value { get; set; }

    public OhmUnit Unit { get; set; }

    public ResistanceViewModel()
    { }

    public ResistanceViewModel(double? value, OhmUnit ohmUnit)
    {
        Value = value;
        Unit = ohmUnit;
    }
}
