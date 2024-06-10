using System.ComponentModel;

namespace ElectronicCircuitSimulator.Core.Enums;

public static class FaradUnitExtensions
{
    public static string GetName(this FaradUnit faradUnit)
    {
        return faradUnit switch
        {
            FaradUnit.Mikrofarad => "Mikrofarad",
            FaradUnit.Millifarad => "Millifarad",
            FaradUnit.Farad => "Farad",
            FaradUnit.Kilofarad => "Kilofarad",
            FaradUnit.Megafarad => "Megafarad",
            _ => throw new InvalidEnumArgumentException(nameof(faradUnit), (byte)faradUnit, typeof(FaradUnit))
        };
    }

    public static string GetSymbol(this FaradUnit faradUnit)
    {
        return faradUnit switch
        {
            FaradUnit.Mikrofarad => "µF",
            FaradUnit.Millifarad => "mF",
            FaradUnit.Farad => "F",
            FaradUnit.Kilofarad => "kF",
            FaradUnit.Megafarad => "MF",
            _ => throw new InvalidEnumArgumentException(nameof(faradUnit), (byte)faradUnit, typeof(FaradUnit))
        };
    }
}
