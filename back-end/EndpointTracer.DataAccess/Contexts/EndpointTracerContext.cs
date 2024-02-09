using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace EndpointTracer.DataAccess
{
    public class EndpointTracerContext : DbContext
    {
        public EndpointTracerContext(DbContextOptions<EndpointTracerContext> options)
            : base(options)
        {

        }   
        public DbSet<Certificate> Certificates { get; set; }    
    }
}