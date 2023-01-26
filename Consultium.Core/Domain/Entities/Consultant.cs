using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
  [Table("Consultants")]
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
    public Boolean HasAsignment { get; set; }

    [ForeignKey("AssignedToCustomerId")]
    public Guid Assignment { get; set; }
  }
}