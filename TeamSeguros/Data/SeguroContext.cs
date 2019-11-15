using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSeguros.Models;

namespace TeamSeguros.Data
{
    public class SeguroContext : DbContext
    {

        public DbSet<Client> Client { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        public SeguroContext(DbContextOptions<SeguroContext> options)
            :base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
