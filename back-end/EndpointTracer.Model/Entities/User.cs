using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EndpointTracer.Model;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(30)")]
    public string Username { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(10)")]
    public string Role { get; set; } = string.Empty;


    [Required]
    public DateTime CreatedAt { get; set; }


    public ICollection<Certificate> Certificates { get; set; } = null!;
    
}
