using System.Collections.Generic;
using System.Linq;
using BabySitter.Core.BabySitters.Models;

namespace BabySitter.Specs.BabySitters
{
    public static class SitterModelExtensions
    {
        public static SitterModel FindByName(this IEnumerable<SitterModel> sitters, string firstName, string lastName)
        {
            return sitters.Where(s => s.FirstName == firstName)
                .Single(s => s.LastName == lastName);
        } 
    }
}