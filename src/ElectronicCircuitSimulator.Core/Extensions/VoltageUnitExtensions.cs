using System.ComponentModel;

namespace ElectronicCircuitSimulator.Core.Enums;

public static class VoltUnitExtensions
{
    public static string GetName(this VoltUnit voltUnit)
    {
        return voltUnit switch
        {
            VoltUnit.Mikrovolt => "Mikrovolt",
            VoltUnit.Millivolt => "Millivolt",
            VoltUnit.Volt => "Volt",
            VoltUnit.Kilovolt => "Kilovolt",
            VoltUnit.Megavolt => "Megavolt",
            _ => throw new InvalidEnumArgumentException(nameof(voltUnit), (byte)voltUnit, typeof(VoltUnit))
        };
    }

    public static string GetSymbol(this VoltUnit voltUnit)
    {
        return voltUnit switch
        {
            VoltUnit.Mikrovolt => "µV",
            VoltUnit.Millivolt => "mV",
            VoltUnit.Volt => "V",
            VoltUnit.Kilovolt => "kV",
            VoltUnit.Megavolt => "MV",
            _ => throw new InvalidEnumArgumentException(nameof(voltUnit), (byte)voltUnit, typeof(VoltUnit))
        };
    }
}

