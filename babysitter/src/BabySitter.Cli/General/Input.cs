using System;

namespace BabySitter.Cli.General
{
    public interface IInput
    {
        string ReadLine();
    }

    public class Input : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}