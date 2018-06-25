using System;

namespace BabySitter.Web.Test.General
{
    public static class ModelFactory
    {
        public static Core.Entities.BabySitter CreateBabySitter(string firstName = null, string lastName = null)
        {
            return new Core.Entities.BabySitter
            {
                FirstName = firstName ?? Guid.NewGuid().ToString(),
                LastName = lastName ?? Guid.NewGuid().ToString()
            };
        }
    }
}