using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BabySitter.Core.BabySitters.Entities;
using BabySitter.Core.BabySitters.Shifts.Models;
using BabySitter.Core.BabySitters.Shifts.Validation;
using NodaTime;

namespace BabySitter.Core.BabySitters.Shifts.Entities
{
    public class Shift
    {
        private static readonly Func<Shift, ShiftModel> ToModelFunc = ToModelExpression().Compile();
        
        [Key] public int Id { get; set; }

        [Required] public LocalDateTime StartTime { get; set; }

        [Required] public LocalDateTime Bedtime { get; set; }
        
        public HourlyRates HourlyRates { get; set; }

        public long? AmountCharged { get; set; }
        
        [Required]
        public Sitter Sitter { get; set; }

        public LocalDateTime? EndTime { get; set; }

        public List<Shift> GetShiftsForSitter()
        {
            return (Sitter?.Shifts ?? new List<Shift>());
        }

        public long? CalculateCharge()
        {
            if (!EndTime.HasValue)
                return null;
            
            return GetNormalCharge()
                   + GetBedtimeToMidnightCharge()
                   + GetAfterMidnightCharge();
        }
        
        public static Expression<Func<Shift, ShiftModel>> ToModelExpression()
        {
            return s => new ShiftModel
            {
                Id = s.Id,
                SitterId = s.Sitter.Id,
                Bedtime = s.Bedtime,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                AmountCharged = s.AmountCharged,
                HourlyRate = s.HourlyRates.Standard,
                HourlyRateAfterMidnight = s.HourlyRates.AfterMidnight,
                HourlyRateBetweenBedtimeAndMidnight = s.HourlyRates.BetweenBedtimeAndMidnight
            };
        }

        public ShiftModel ToModel()
        {
            return ToModelFunc(this);
        }
        
        private long GetNormalCharge()
        {
            var hours = EndTime.Value < Bedtime
                ? (EndTime.Value - StartTime).Hours
                : (Bedtime - StartTime).Hours;

            return hours * HourlyRates.Standard;
        }
        
        private long GetBedtimeToMidnightCharge()
        {
            var midnight = GetMidnight(StartTime);

            long hours = 0;
            if (EndTime.Value > midnight)
                hours = (midnight - Bedtime).Hours;

            else if (EndTime.Value > Bedtime)
                hours = (EndTime.Value - Bedtime).Hours;

            return hours * HourlyRates.BetweenBedtimeAndMidnight;
        }
        
        private long GetAfterMidnightCharge()
        {
            var midnight = GetMidnight(StartTime);

            if (EndTime.Value < midnight)
                return 0;

            return EndTime.Value.Hour * HourlyRates.AfterMidnight;
        }
        
        private static LocalDateTime GetMidnight(LocalDateTime arrivalTime)
        {
            return arrivalTime
                .Date
                .PlusDays(1)
                .AtMidnight();
        }
    }
}