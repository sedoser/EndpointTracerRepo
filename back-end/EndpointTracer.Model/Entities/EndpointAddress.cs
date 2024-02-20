using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EndpointTracer.Model.Entities
{
    public class EndpointAddress
    {
        [Key]
        [Required]
        public int EndpointAddressId { get; set; }  

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Endpoint { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Datapower { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Env { get; set; } = null!;
        [JsonIgnore]
        public ExternalDp ExternalDp { get; set; }
    }
}