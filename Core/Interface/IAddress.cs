using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IAddress
    {
        int Id { get; set; }
        string? City { get; set; }
        string? Street { get; set; }
        string? PostalCode { get; set; }
    }
}
