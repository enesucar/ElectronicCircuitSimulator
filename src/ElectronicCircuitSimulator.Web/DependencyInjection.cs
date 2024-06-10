using Blazored.LocalStorage;
using Blazored.Toast;
using ElectronicCircuitSimulator.Core.Interfaces;
using ElectronicCircuitSimulator.Core.Services;
using ElectronicCircuitSimulator.Web.Mappers;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(
        this IServiceCollection services)
    {
        services
            .AddRazorComponents()
            .AddInteractiveServerComponents();

        services
            .AddSingleton<IFaradUnitConverter, FaradUnitConverter>()
            .AddSingleton<IHertzUnitConverter, HertzUnitConverter>()
            .AddSingleton<IOhmUnitConverter, OhmUnitConverter>()
            .AddSingleton<IVoltUnitConverter, VoltUnitConverter>()
            .AddSingleton<IAmperUnitConverter, AmperUnitConverter>()
            .AddSingleton<IElectricCircuitCalculator, ElectricCircuitCalculator>();

        services
            .AddSingleton<CalculateForCircuitsMapper>()
            .AddSingleton<CapacitanceMapper>()
            .AddSingleton<CurrentMapper>()
            .AddSingleton<FrequencyMapper>()
            .AddSingleton<ResistanceMapper>()
            .AddSingleton<VoltageMapper>();

        services.AddBlazoredToast();

        services.AddBlazoredLocalStorage();

        return services;
    }
}
