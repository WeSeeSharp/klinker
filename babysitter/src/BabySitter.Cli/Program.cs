using System;
using BabySitter.Cli.General;
using BabySitter.Core;
using BabySitter.Core.BabySitters;
using BabySitter.Core.BabySitters.Shifts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BabySitter.Cli
{
    public class Program
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly NightlyChargeCalculator _calculator;

        public Program(IServiceCollection services)
            : this(services.BuildServiceProvider())
        {
        }

        public Program(IServiceProvider provider)
            : this(provider.GetRequiredService<IInput>(), provider.GetRequiredService<IOutput>(), provider.GetRequiredService<NightlyChargeCalculator>())
        {
            
        }

        public Program(IInput input, IOutput output, NightlyChargeCalculator calculator)
        {
            _input = input;
            _output = output;
            _calculator = calculator;
        }

        public static void Main(string[] args)
        {
            var services = new ServiceCollection().AddBabySitterCli();
            var program = new Program(services);
            program.Execute();
        }

        public void Execute()
        {
            do
            {
                CalculateTotal();
                _output.WriteLine("Enter another shift? (Y/N)");
            } while (_input.ReadLine() != "N");
        }

        private void CalculateTotal()
        {
            _output.WriteLine("Please enter start time:");
            var startTime = _input.ReadLine().ToLocalDateTime();
            
            _output.WriteLine("Please enter leave time:");
            var leaveTimeText = _input.ReadLine();
            var leaveTime = leaveTimeText.ToLowerInvariant().Contains("am")
                ? leaveTimeText.ToLocalDateTime().PlusDays(1)
                : leaveTimeText.ToLocalDateTime();
            
            _output.WriteLine("Please enter bedtime:");
            var bedTime = _input.ReadLine().ToLocalDateTime();

            var parameters = new NightlyChargeArgs(startTime, bedTime, leaveTime);
            var total = _calculator.Calculate(parameters);
            _output.WriteLine($"Total: ${total}");
        }
    }
}