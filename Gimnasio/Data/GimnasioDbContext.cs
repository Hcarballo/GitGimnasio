using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gimnasio.Models;
using Microsoft.AspNetCore.Identity;

namespace Gimnasio.Data
{
    public class GimnasioDbContext : IdentityDbContext<ApplicationUser>
    {
        public GimnasioDbContext(DbContextOptions<GimnasioDbContext> options)
            : base(options)
        {
        }

        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Dia_Clase> Dias_Clases { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<IdentityRole> identityRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Actividad>().ToTable("Actividad");
            modelBuilder.Entity<Blog>().ToTable("Blog");
            modelBuilder.Entity<Clase>().ToTable("Clase");
            modelBuilder.Entity<Cuota>().ToTable("Cuota");
            modelBuilder.Entity<Dia_Clase>().ToTable("Dia_Clase");
            modelBuilder.Entity<Gym>().ToTable("Gym");
            modelBuilder.Entity<Horario>().ToTable("Horario");
            modelBuilder.Entity<Pagina>().ToTable("Pagina");
            modelBuilder.Entity<Pago>().ToTable("Pago");
            modelBuilder.Entity<Profesor>().ToTable("Profesor");
            modelBuilder.Entity<Socio>().ToTable("Socio");
        }
    }
}
