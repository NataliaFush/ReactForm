using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Models
{
    internal class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        [StringLength(100)]
        public string? Email { get; set; }
        [Range(0, 100)]
        public int? Age { get; set; }
        public DateTime? CreateData { get; set; }
        [MinLength(5)]
        [StringLength(50)]
        public string? Password { get; set; }
        public Address? Address { get; set; }
        public int? AddressId { get; set; }

    }
}
