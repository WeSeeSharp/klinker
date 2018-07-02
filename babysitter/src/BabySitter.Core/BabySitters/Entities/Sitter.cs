using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BabySitter.Core.BabySitters.Models;
using BabySitter.Core.BabySitters.Shifts.Entities;

namespace BabySitter.Core.BabySitters.Entities
{
    public class Sitter
    {
        private static readonly Func<Sitter, SitterModel> ToModelFunc = ToModelExpression().Compile();
        

        [Key] public int Id { get; set; }

        [Required] [MaxLength(256)] public string FirstName { get; set; }

        [Required] [MaxLength(256)] public string LastName { get; set; }

        public HourlyRates HourlyRates { get; set; }
        
        public List<Shift> Shifts { get; set; }

        public Sitter()
        {
            Shifts = new List<Shift>();
        }
        
        public SitterModel ToModel()
        {
            return ToModelFunc(this);
        }

        public static Expression<Func<Sitter, SitterModel>> ToModelExpression()
        {
            return b => new SitterModel
            {
                FirstName = b.FirstName,
                LastName = b.LastName,
                Id = b.Id,
                HourlyRate = b.HourlyRates.Standard,
                HourlyRateAfterMidnight = b.HourlyRates.AfterMidnight,
                HourlyRateBetweenBedtimeAndMidnight = b.HourlyRates.BetweenBedtimeAndMidnight
            };
        }
    }
}