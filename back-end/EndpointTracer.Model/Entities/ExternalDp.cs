using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EndpointTracer.Model.Entities
{
    public class ExternalDp
{
    [Key]
    public int ExternalDpId { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string DpName { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(200)")]
    public string ManagementUrl { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Type { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(1000)")]
    public string Description { get; set; } = string.Empty;

    public ICollection<EndpointAddress> EndpointAddresses { get; set; } = new List<EndpointAddress>();

    public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

}
}