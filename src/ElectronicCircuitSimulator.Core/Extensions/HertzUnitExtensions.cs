using System.ComponentModel;

namespace ElectronicCircuitSimulator.Core.Enums;

public static class HertzUnitExtensions
{
    public static string GetName(this HertzUnit hertzUnit)
    {
        return hertzUnit switch
        {
            HertzUnit.Mikrohertz => "Mikrohertz",
            HertzUnit.Millihertz => "Millihertz",
            HertzUnit.Hertz => "Hertz",
            HertzUnit.Kilohertz => "Kilohertz",
            HertzUnit.Megahertz => "Megahertz",
            _ => throw new InvalidEnumArgumentException(nameof(hertzUnit), (byte)hertzUnit, typeof(HertzUnit))
        };
    }

    public static string GetSymbol(this HertzUnit hertzUnit)
    {
        return hertzUnit switch
        {
            HertzUnit.Mikrohertz => "µHz",
            HertzUnit.Millihertz => "mHz",
            HertzUnit.Hertz => "Hz",
            HertzUnit.Kilohertz => "kHz",
            HertzUnit.Megahertz => "MHz",
            _ => throw new InvalidEnumArgumentException(nameof(hertzUnit), (byte)hertzUnit, typeof(HertzUnit))
        };
    }
}
