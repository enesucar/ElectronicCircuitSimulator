using System.ComponentModel;

namespace ElectronicCircuitSimulator.Core.Enums;

public static class OhmUnitExtensions
{
    public static string GetName(this OhmUnit ohmUnit)
    {
        return ohmUnit switch
        {
            OhmUnit.Mikroohm => "Mikroohm",
            OhmUnit.Milliohm => "Milliohm",
            OhmUnit.Ohm => "Ohm",
            OhmUnit.Kiloohm => "Kiloohm",
            OhmUnit.Megaohm => "Megaohm",
            _ => throw new InvalidEnumArgumentException(nameof(ohmUnit), (byte)ohmUnit, typeof(OhmUnit))
        };
    }

    public static string GetSymbol(this OhmUnit ohmUnit)
    {
        return ohmUnit switch
        {
            OhmUnit.Mikroohm => "µΩ",
            OhmUnit.Milliohm => "mΩ",
            OhmUnit.Ohm => "Ω",
            OhmUnit.Kiloohm => "kΩ",
            OhmUnit.Megaohm => "MΩ",
            _ => throw new InvalidEnumArgumentException(nameof(ohmUnit), (byte)ohmUnit, typeof(OhmUnit))
        };
    }
}
