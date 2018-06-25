using System.Collections.Generic;
using BabySitter.Cli.General;

namespace BabySitter.Cli.Test.Fakes
{
    public class FakeInput : IInput
    {
        private readonly Queue<string> _lines;

        public FakeInput()
        {
            _lines = new Queue<string>();
        }

        public string ReadLine()
        {
            return _lines.Dequeue();
        }

        public void EnterLine(string line)
        {
            _lines.Enqueue(line);
        }
    }
}