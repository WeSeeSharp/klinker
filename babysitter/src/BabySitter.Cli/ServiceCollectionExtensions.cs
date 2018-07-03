using BabySitter.Cli.General;
using BabySitter.Core;
using BabySitter.Core.BabySitters;
using BabySitter.Core.BabySitters.Shifts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Cli
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBabySitterCli(this IServiceCollection services)
        {
            services.AddSingleton<IOutput, Output>()
                .AddSingleton<IInput, Input>()
                .AddTransient<NightlyChargeCalculator>();
            return services;
        }
    }
}