using System;
using BabySitter.Core.Entities;

namespace BabySitter.Web.Test.General
{
    public static class ModelFactory
    {
        public static Sitter CreateBabySitter(string firstName = null, string lastName = null)
        {
            return new Sitter
            {
                FirstName = firstName ?? Guid.NewGuid().ToString(),
                LastName = lastName ?? Guid.NewGuid().ToString(),
                HourlyRates = new HourlyRates()
            };
        }
    }
}