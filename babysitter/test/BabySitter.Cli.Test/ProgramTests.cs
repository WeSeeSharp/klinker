using BabySitter.Cli.General;
using BabySitter.Cli.Test.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace BabySitter.Cli.Test
{
    public class ProgramTests
    {
        private readonly Program _program;
        private readonly FakeOutput _output;
        private readonly FakeInput _input;

        public ProgramTests()
        {
            _input = new FakeInput();
            _input.EnterLine("5:00 PM");
            _input.EnterLine("9:00 PM");
            _input.EnterLine("9:00 PM");
            
            _output = new FakeOutput();
            var services = new ServiceCollection()
                .AddBabySitterCli()
                .Replace(new ServiceDescriptor(typeof(IOutput), p => _output, ServiceLifetime.Singleton))
                .Replace(new ServiceDescriptor(typeof(IInput), p => _input, ServiceLifetime.Singleton));
            
            _program = new Program(services);
        }
        
        [Fact]
        public void ShouldAskForStartTime()
        {
            _program.Execute();
            
            Assert.Contains("Please enter start time:", _output.Messages);
        }
        
        [Fact]
        public void ShouldAskForLeaveTime()
        {
            _program.Execute();

            Assert.Contains("Please enter leave time:", _output.Messages);
        }
        
        [Fact]
        public void ShouldAskForBedtime()
        {
            _program.Execute();
            
            Assert.Contains("Please enter bedtime:", _output.Messages);
        }
        
        [Fact]
        public void ShouldShowChargeAmountForTonight()
        {
            _program.Execute();
            Assert.Contains("Total: $48", _output.Messages);
        }
    }
}