using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BabySitter.Core.Models;
using NodaTime;

namespace BabySitter.Core.Entities
{
    public class Shift
    {
        private static Func<Shift, ShiftModel> ToModelFunc = ToModelExpression().Compile();
        
        [Key] public int Id { get; set; }

        [Required] public LocalDateTime StartTime { get; set; }

        [Required] public LocalDateTime Bedtime { get; set; }
        
        public HourlyRates HourlyRates { get; set; }
        
        [Required]
        public Sitter Sitter { get; set; }

        public LocalDateTime? EndTime { get; set; }

        public static Expression<Func<Shift, ShiftModel>> ToModelExpression()
        {
            return s => new ShiftModel
            {
                Id = s.Id,
                SitterId = s.Sitter.Id,
                Bedtime = s.Bedtime,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                HourlyRate = s.HourlyRates.Standard,
                HourlyRateAfterMidnight = s.HourlyRates.AfterMidnight,
                HourlyRateBetweenBedtimeAndMidnight = s.HourlyRates.BetweenBedtimeAndMidnight
            };
        }

        public ShiftModel ToModel()
        {
            return ToModelFunc(this);
        }
    }
}