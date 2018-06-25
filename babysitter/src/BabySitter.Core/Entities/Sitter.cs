using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BabySitter.Core.Models;

namespace BabySitter.Core.Entities
{
    public class Sitter
    {
        private static readonly Func<Sitter, SitterModel> ToModelFunc = ToModelExpression().Compile();
        public const int StandardHourlyRateBetweenBedtimeAndMidnight = 8;
        public const int StandardHourlyRate = 12;
        public const int StandardHourlyRateAfterMidnight = 16;

        [Key] public int Id { get; set; }

        [Required] [MaxLength(256)] public string FirstName { get; set; }

        [Required] [MaxLength(256)] public string LastName { get; set; }

        [Required] public int HourlyRate { get; set; } = StandardHourlyRate;

        [Required] public int HourlyRateAfterMidnight { get; set; } = StandardHourlyRateAfterMidnight;

        [Required]
        public int HourlyRateBetweenBedtimeAndMidnight { get; set; } = StandardHourlyRateBetweenBedtimeAndMidnight;

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
                HourlyRate = b.HourlyRate,
                HourlyRateAfterMidnight = b.HourlyRateAfterMidnight,
                HourlyRateBetweenBedtimeAndMidnight = b.HourlyRateBetweenBedtimeAndMidnight
            };
        }
    }
}