using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  [Table("consultants")]
  public class Consultant
  {
    [Key]
    public Guid ConsultantId { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    public string[] Skills { get; set; }

    [Required]
    public Boolean HasAssignment { get; set; }

    public Guid? CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public Customer? Customer { get; set; }
  }
}