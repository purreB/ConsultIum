using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  [Table("Customers")]
  public class Customer
  {
    [Key]
    public Guid CustomerId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CustomerName { get; set; }

    [ForeignKey("ConsultantsIds")]
    public List<Guid> Consultants { get; set; }
  }
}