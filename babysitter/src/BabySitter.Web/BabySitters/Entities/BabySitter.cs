using System.ComponentModel.DataAnnotations;

namespace BabySitter.Web.BabySitters.Entities
{
    public class BabySitter
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string LastName { get; set; }
    }
}