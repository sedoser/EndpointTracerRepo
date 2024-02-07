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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost;Database=EndpointTracerDb;User Id=SA;Password=strongPwd123+;TrustServerCertificate=Yes;");                                                                    
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Certificate> Certificates { get; set; }    
    }
}