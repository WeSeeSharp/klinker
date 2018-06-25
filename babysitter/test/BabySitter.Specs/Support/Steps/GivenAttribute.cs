using System;

namespace BabySitter.Specs.Support.Steps
{
    [AttributeUsage(AttributeTargets.Method)]
    public class GivenAttribute : StepAttribute
    {
        public GivenAttribute(string regex)
            : base(regex)
        {
        }
    }
}