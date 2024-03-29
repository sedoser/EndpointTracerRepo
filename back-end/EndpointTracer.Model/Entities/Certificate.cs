﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Text.Json.Serialization;
using EndpointTracer.Model.Entities;

namespace EndpointTracer.Model;

public class Certificate
{
    [Key]
    public int ?CertificateId { get; set; }

    [Required]
    [Column(TypeName = "varchar(3000)")]
    public string Pem { get; set; } = string.Empty;

    [Required]
    public DateTime ExpirationDate{ get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    [Column(TypeName = "varchar(20)")]
    public string Type { get; set; } = string.Empty;

    [Required]
    [Column(TypeName = "varchar(1000)")]
    public string Desc { get; set; } = string.Empty;  
    public int ExternalDpId { get; set; }
    [JsonIgnore]
    public ExternalDp ExternalDp { get; set; } = null!;
}
