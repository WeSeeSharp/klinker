using System;

namespace BabySitter.Web.Test.General
{
    public static class ModelFactory
    {
        public static BabySitters.Entities.BabySitter CreateBabySitter(string firstName = null, string lastName = null)
        {
            return new BabySitters.Entities.BabySitter
            {
                FirstName = firstName ?? Guid.NewGuid().ToString(),
                LastName = lastName ?? Guid.NewGuid().ToString()
            };
        }
    }
}