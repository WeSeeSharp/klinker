using System.Collections.Generic;
using BabySitter.Cli.General;

namespace BabySitter.Cli.Test.Fakes
{
    public class FakeOutput : IOutput
    {
        private readonly List<string> _messages;
        
        public string[] Messages => _messages.ToArray();

        public FakeOutput()
        {
            _messages = new List<string>();
        }
        
        public void WriteLine(string message)
        {
            _messages.Add(message);
        }
    }
}