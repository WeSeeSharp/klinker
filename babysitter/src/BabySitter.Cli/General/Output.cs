using System;

namespace BabySitter.Cli.General
{
    public interface IOutput
    {
        void WriteLine(string message);
    }

    public class Output : IOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}