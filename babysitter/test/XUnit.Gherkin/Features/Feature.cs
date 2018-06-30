using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Gherkin.Steps;

namespace Xunit.Gherkin.Features
{
    public class Feature
    {
        public StepDefinition[] Steps { get; }
        public ITestOutputHelper Output { get; }
        public object[] Services { get; }

        public Feature(ITestOutputHelper output, params object[] services)
        {
            Output = output;
            Services = services;
            Steps = StepDefinitionLocator.Instance.GetDefinitions();
        }

        public async Task Given(string text)
        {
            Output.WriteLine($"Given {text}");
            await ExecuteStep<GivenAttribute>(text);
        }

        public async Task When(string text)
        {
            Output.WriteLine($"When {text}");
            await ExecuteStep<WhenAttribute>(text);
        }

        public async Task Then(string text)
        {
            Output.WriteLine($"Then {text}");
            await ExecuteStep<ThenAttribute>(text);
        }
        
        private async Task ExecuteStep<T>(string text)
        {
            var step = Steps.SingleOrDefault(s => s.IsMatch<T>(text))
                       ?? throw new InvalidOperationException($"No matching step definition was found for: {text}");

            await step.Execute(text, Output, Services);
        }
    }
}