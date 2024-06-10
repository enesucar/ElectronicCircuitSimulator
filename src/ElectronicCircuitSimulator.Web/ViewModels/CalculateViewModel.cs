using ElectronicCircuitSimulator.Core.Constants;
using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace ElectronicCircuitSimulator.Web.ViewModels;

public class CalculateViewModel
{
    public ResistanceViewModel Resistance_g { get; set; }

    public ResistanceViewModel Resistance_a { get; set; }

    public ResistanceViewModel Resistance_b { get; set; }

    public ResistanceViewModel Resistance_E { get; set; }

    public ResistanceViewModel Resistance_y { get; set; }

    public CapacitanceViewModel Capacitance_1 { get; set; }

    public CapacitanceViewModel Capacitance_2 { get; set; }

    public VoltageViewModel Voltage_CC { get; set; }

    public VoltageViewModel Voltage_BE { get; set; }

    public double Beta_0 { get; set; }

    public CurrentViewModel Current_B { get; set; }

    public CurrentViewModel Current_C { get; set; }

    public CurrentViewModel Current_E { get; set; }

    public VoltageViewModel Voltage_CE { get; set; }

    public VoltageViewModel Voltage_CB { get; set; }

    public OperationRegion OperationRegion { get; set; }

    public FrequencyViewModel Frequency_C1 { get; set; }

    public FrequencyViewModel Frequency_C2 { get; set; }

    public FrequencyViewModel Frequency_L { get; set; }

    public double? VoltageGain { get; set; }

    public ResistanceViewModel Resistance_Pi { get; set; }

    public double? GMV_Pi { get; set; }

    public ResistanceViewModel Resistance_B { get; set; }

    public VoltageViewModel Voltage_B { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public CalculateViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Initialize();
    }

    private void Initialize()
    {
        Resistance_g = new ResistanceViewModel(null, OhmUnit.Ohm);
        Resistance_a = new ResistanceViewModel(null, OhmUnit.Ohm);
        Resistance_b = new ResistanceViewModel(null, OhmUnit.Ohm);
        Resistance_E = new ResistanceViewModel(null, OhmUnit.Ohm);
        Resistance_y = new ResistanceViewModel(null, OhmUnit.Ohm);
        Capacitance_1 = new CapacitanceViewModel(null, FaradUnit.Farad);
        Capacitance_2 = new CapacitanceViewModel(null, FaradUnit.Farad);
        Voltage_CC = new VoltageViewModel(null, VoltUnit.Volt);
        Voltage_BE = new VoltageViewModel(DefaultConstants.Voltage_BE_DefaultValue, VoltUnit.Volt);
        Beta_0 = DefaultConstants.BetaZeroDefaultValue;
        Current_B = new CurrentViewModel(null, AmperUnit.Amper);
        Current_C = new CurrentViewModel(null, AmperUnit.Amper);
        Current_E = new CurrentViewModel(null, AmperUnit.Amper);
        Voltage_CE = new VoltageViewModel(null, VoltUnit.Volt);
        Voltage_CB = new VoltageViewModel(null, VoltUnit.Volt);
        OperationRegion = OperationRegion.None;
        Frequency_C1 = new FrequencyViewModel(null, HertzUnit.Hertz);
        Frequency_C2 = new FrequencyViewModel(null, HertzUnit.Hertz);
        Frequency_L = new FrequencyViewModel(null, HertzUnit.Hertz);
        VoltageGain = null;
        Resistance_Pi = new ResistanceViewModel(null, OhmUnit.Ohm);
        GMV_Pi = null;
        Resistance_B = new ResistanceViewModel(null, OhmUnit.Ohm);
        Voltage_B = new VoltageViewModel(null, VoltUnit.Volt);
    }
}
