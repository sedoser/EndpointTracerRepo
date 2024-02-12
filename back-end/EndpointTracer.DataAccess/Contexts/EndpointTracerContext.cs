using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndpointTracer.Model;
using EndpointTracer.Model.Entities;
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
        public DbSet<ExternalDp> ExternalDps { get; set; }  

        public DbSet<EndpointAddress> EndpointAddresses { get; set; }

        public DbSet<Certificate> Certificates { get; set ;}  
    }
}