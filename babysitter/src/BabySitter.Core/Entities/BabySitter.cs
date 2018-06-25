using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using BabySitter.Core.Models;

namespace BabySitter.Core.Entities
{
    public class BabySitter
    {
        private static readonly Func<BabySitter, BabySitterModel> ToModelFunc = ToModelExpression().Compile();
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }

        public BabySitterModel ToModel()
        {
            return ToModelFunc(this);
        }

        public static Expression<Func<BabySitter, BabySitterModel>> ToModelExpression()
        {
            return b => new BabySitterModel
            {
                FirstName = b.FirstName,
                LastName = b.LastName,
                Id = b.Id
            };
        }
    }
}