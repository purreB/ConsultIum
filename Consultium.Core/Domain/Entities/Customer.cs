using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  [Table("customers")]
  public class Customer
  {
    [Key]
    public Guid CustomerId { get; set; }

    [Required]
    [MaxLength(50)]
    public string CompanyName { get; set; }

    public List<Guid> ConsultantIds { get; set; }

    [ForeignKey("ConsultantIds")]
    public List<Consultant> Consultants { get; set; }
  }
}