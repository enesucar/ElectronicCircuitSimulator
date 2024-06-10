using System.ComponentModel;

namespace ElectronicCircuitSimulator.Core.Enums;

public static class AmperUnitExtensions
{
    public static string GetName(this AmperUnit amperUnit)
    {
        return amperUnit switch
        {
            AmperUnit.Mikroamper => "Mikroamper",
            AmperUnit.Milliamper => "Milliamper",
            AmperUnit.Amper => "Amper",
            AmperUnit.Kiloamper => "Kiloamper",
            AmperUnit.Megaamper => "Megaamper",
            _ => throw new InvalidEnumArgumentException(nameof(amperUnit), (byte)amperUnit, typeof(AmperUnit))
        };
    }

    public static string GetSymbol(this AmperUnit amperUnit)
    {
        return amperUnit switch
        {
            AmperUnit.Mikroamper => "µA",
            AmperUnit.Milliamper => "mA",
            AmperUnit.Amper => "A",
            AmperUnit.Kiloamper => "kA",
            AmperUnit.Megaamper => "MA",
            _ => throw new InvalidEnumArgumentException(nameof(amperUnit), (byte)amperUnit, typeof(AmperUnit))
        };
    }
}

