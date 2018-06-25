using System;
using BabySitter.Cli.General;
using BabySitter.Core;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Cli
{
    public class Program
    {
        private readonly IServiceProvider _provider;

        public Program(IServiceCollection services)
        {
            _provider = services.BuildServiceProvider();
        }

        public static void Main(string[] args)
        {
            var services = new ServiceCollection().AddBabySitterCli();
            var program = new Program(services);
            program.Execute();
        }

        public void Execute()
        {
            var output = _provider.GetService<IOutput>();
            var input = _provider.GetService<IInput>();
            var calculator = _provider.GetService<NightlyChargeCalculator>();
            
            output.WriteLine("Please enter start time:");
            var startTime = input.ReadLine().ToLocalDateTime();
            
            output.WriteLine("Please enter leave time:");
            var leaveTime = input.ReadLine().ToLocalDateTime();
            
            output.WriteLine("Please enter bedtime:");
            var bedTime = input.ReadLine().ToLocalDateTime();

            var parameters = new NightlyChargeParameters(startTime, bedTime, leaveTime);
            var total = calculator.Calculate(parameters);
            output.WriteLine($"Total: ${total}");
        }
    }
}