using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace EndpointTracer.Model;

public class Certificate
{
    [Key]
    public int CertificateId { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Token { get; set; } = string.Empty;

    [Required]
    public DateTime ExpirationDate{ get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Type { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(1000)")]
    public string Info { get; set; } = string.Empty;
    
}
