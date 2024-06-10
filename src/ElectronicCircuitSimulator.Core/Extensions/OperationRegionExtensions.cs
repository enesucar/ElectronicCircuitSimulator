using System.ComponentModel;

namespace ElectronicCircuitSimulator.Core.Enums;

public static class OperationRegionExtensions
{
    public static string GetName(this OperationRegion operationRegion)
    {
        return operationRegion switch
        {
            OperationRegion.None => "Hiçbiri",
            OperationRegion.Active => "Aktif Bölge",
            OperationRegion.Saturation => "Doyum Bölgesi",
            OperationRegion.CutOff => "Kesim Bölgesi",
            _ => throw new InvalidEnumArgumentException(nameof(operationRegion), (byte)operationRegion, typeof(OperationRegion))
        };
    }
}
