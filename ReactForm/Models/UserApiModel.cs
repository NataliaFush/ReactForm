using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UserApiModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(10)]
        public string? Name { get; set; }
       
        [Range(0, 100)]
        public int? Age { get; set; }
        [MinLength(5)]
        [StringLength(50)]
        public string? Password { get; set; }
        
        [StringLength(100)]
        public string? Email { get; set; }
        public AddressModel? Address { get; set; }
    }

    public class AddressModel
    {
        [StringLength(100)]
        public string? City { get; set; }
        [StringLength(100)]
        public string? Street { get; set; }

        [Required]
        [StringLength(100)]
        public string? PostalCode { get; set; }
    }
}
