using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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