using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraLaboralBackend.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }

        public DbSet<Area> Area { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().HasKey(m => m.Id);

            modelBuilder.Entity<Colaborador>().HasKey(m => m.Id);

            modelBuilder.Entity<Area>().HasKey(m => m.AreaId);

            //modelBuilder.Entity<Colaborador>().HasOne(p => p.Fk_Area)
            //    .WithMany(b => b.Colaboradores)
            //    .HasForeignKey(t => t.Fk_Area);

            base.OnModelCreating(modelBuilder);
        }

    }
}
