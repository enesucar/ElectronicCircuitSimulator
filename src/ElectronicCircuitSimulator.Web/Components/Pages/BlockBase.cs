using BlazorBootstrap;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;
using ElectronicCircuitSimulator.Core.Services;
using ElectronicCircuitSimulator.Web.Constants;
using ElectronicCircuitSimulator.Web.Mappers;
using ElectronicCircuitSimulator.Web.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ElectronicCircuitSimulator.Web.Components.Pages;

public class BlockBase : ComponentBase
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [Inject]
    public IAmperUnitConverter AmperUnitConverter { get; set; }

    [Inject]
    public IFaradUnitConverter FaradUnitConverter { get; set; }

    [Inject]
    public IHertzUnitConverter HertzUnitConverter { get; set; }

    [Inject]
    public IVoltUnitConverter VoltUnitConverter { get; set; }

    [Inject]
    public IOhmUnitConverter OhmUnitConverter { get; set; }

    [Inject]
    public IElectricCircuitCalculator ElectricCircuitCalculator { get; set; }

    [Inject]
    public CalculateForCircuitsMapper CalculateForCircuitsMapper { get; set; }

    [Inject]
    public ILocalStorageService LocalStorage { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IJSRuntime JS { get; set; }

    [Inject]
    public IToastService ToastService { get; set; }


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public bool CheckIfAnyModelValueNull(CalculateViewModel model)
    {
        if (!model.Resistance_g.Value.HasValue ||
            !model.Resistance_a.Value.HasValue ||
            !model.Resistance_b.Value.HasValue ||
            !model.Resistance_E.Value.HasValue ||
            !model.Resistance_y.Value.HasValue ||
            !model.Capacitance_1.Value.HasValue ||
            !model.Capacitance_2.Value.HasValue ||
            !model.Voltage_CC.Value.HasValue ||
            !model.Voltage_BE.Value.HasValue)
        {
            return false;
        }
        return true;
    }

    public void ConvertToAmperUnit(ChangeEventArgs e, CurrentViewModel model)
    {
        if (e.Value == null)
        {
            return;
        }

        if (model.Value == null)
        {
            return;
        }

        Enum.TryParse((string)e.Value, out AmperUnit newCurrentUnit);
        var newValue = AmperUnitConverter.Convert(model.Value.Value, model.Unit, newCurrentUnit);

        model.Unit = newCurrentUnit;
        model.Value = newValue;

        StateHasChanged();
    }
     
    public void ConvertToVoltUnit(ChangeEventArgs e, VoltageViewModel model)
    {
        if (e.Value == null)
        {
            return;
        }

        if (model.Value == null)
        {
            return;
        }

        Enum.TryParse((string)e.Value, out VoltUnit newVoltUnit);
        var newValue = VoltUnitConverter.Convert(model.Value.Value, model.Unit, newVoltUnit);

        model.Unit = newVoltUnit;
        model.Value = newValue;

        StateHasChanged();
    }

    public void ConvertToHertzUnit(ChangeEventArgs e, FrequencyViewModel model)
    {
        if (e.Value == null)
        {
            return;
        }

        if (model.Value == null)
        {
            return;
        }

        Enum.TryParse((string)e.Value, out HertzUnit newHertzUnit);
        var newValue = HertzUnitConverter.Convert(model.Value.Value, model.Unit, newHertzUnit);

        model.Unit = newHertzUnit;
        model.Value = newValue;

        StateHasChanged();
    }

    public void ConvertToFaradUnit(ChangeEventArgs e, CapacitanceViewModel model)
    {
        if (e.Value == null)
        {
            return;
        }

        if (model.Value == null)
        {
            return;
        }

        Enum.TryParse((string)e.Value, out FaradUnit newFaradUnit);
        var newValue = FaradUnitConverter.Convert(model.Value.Value, model.Unit, newFaradUnit);

        model.Unit = newFaradUnit;
        model.Value = newValue;

        StateHasChanged();
    }

    public void ConvertToOhmUnit(ChangeEventArgs e, ResistanceViewModel model)
    {
        if (e.Value == null)
        {
            return;
        }

        if (model.Value == null)
        {
            return;
        }

        Enum.TryParse((string)e.Value, out OhmUnit newOhmUnit);
        var newValue = OhmUnitConverter.Convert(model.Value.Value, model.Unit, newOhmUnit);

        model.Unit = newOhmUnit;
        model.Value = newValue;

        StateHasChanged();
    }

    public double? Round(double? value)
    {
        if (value == null)
        {
            return value;
        }

        double roundedValue = Math.Round(value.Value, 4, MidpointRounding.AwayFromZero);

        if (roundedValue == 0)
        {
            return value;
        }

        return roundedValue;
    }

    public string GetTextOnImage(string name, double? value, string symbol)
    {
        if (value == null)
        {
            return name;
        }
        return $"{name} = {value}{symbol}";
    }
}
