using System;
using BabySitter.Core.BabySitters.Entities;

namespace BabySitter.Core.Test.Utilties
{
    public class ModelFactory
    {
        public static Sitter CreateSitter(
            string firstName = null,
            string lastName = null,
            HourlyRates rates = null)
        {
            return new Sitter
            {
                FirstName = firstName ?? Guid.NewGuid().ToString(),
                LastName = lastName ?? Guid.NewGuid().ToString(),
                HourlyRates = rates ?? HourlyRates.FromStandardRates()
            };
        }
    }
}