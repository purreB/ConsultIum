using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
  [Table("users")]
  public class User
  {
    [Key]
    public Guid UserId { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    [MinLength(5)]
    public string Password { get; set; }

  }
}