using ElectronicCircuitSimulator.Core.Enums;
using ElectronicCircuitSimulator.Core.Interfaces;
using ElectronicCircuitSimulator.Core.Services;

namespace ElectronicCircuitSimulator.Core.Tests;

public class UnitConverterTests
{
    public IAmperUnitConverter AmperUnitConverter { get; set; }
    public IVoltUnitConverter VoltUnitConverter { get; set; }

    public UnitConverterTests()
    {
        AmperUnitConverter = new AmperUnitConverter();
        VoltUnitConverter = new VoltUnitConverter();
    }

    [Fact]
    public void Convert_AmperConversion_ReturnsExceptedResult()
    {
        var value = 10;
        AmperUnit fromAmperUnit = AmperUnit.Amper;
        AmperUnit toAmperUnit = AmperUnit.Milliamper;

        var convertedValue = AmperUnitConverter.Convert(value, fromAmperUnit, toAmperUnit);
        
        Assert.Equal(10_000, convertedValue);
    }

    [Fact]
    public void Convert_VoltConversion_ReturnsExceptedResult()
    {
        var value = 10;
        VoltUnit fromVoltUnit = VoltUnit.Volt;
        VoltUnit toVoltUnit = VoltUnit.Kilovolt;

        var convertedValue = VoltUnitConverter.Convert(value, fromVoltUnit, toVoltUnit);

        Assert.Equal(0.01, convertedValue);
    }
}
