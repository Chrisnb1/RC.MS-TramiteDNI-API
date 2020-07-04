using Microsoft.EntityFrameworkCore;
using RC.MS_TramiteDNI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.MS_TramiteDNI.AccessData
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opcion) : base(opcion)
        {

        }

        public DbSet<TramiteDNI> TramiteDNIs { get; set; }
        public DbSet<NuevoEjemplar> NuevosEjemplares { get; set; }
        public DbSet<Extranjero> Extranjeros { get; set; }
        public DbSet<Nacimiento> Nacimientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Parámetros para la tabla NuevoEjemplar.
            modelBuilder.Entity<NuevoEjemplar>(entity =>
            {
                entity.Property(q => q.NuevoEjemplarId).IsRequired().IsUnicode();
                entity.Property(q => q.Descripcion).HasMaxLength(45).IsRequired();
            }
            );

            //Parámetros para la tabla Extranjero.
            modelBuilder.Entity<Extranjero>(entity =>
            {
                entity.Property(q => q.ExtranjeroId).IsRequired().IsUnicode();
                entity.Property(q => q.PaisOrigen).HasMaxLength(45).IsRequired();
            }
            );

            //Parámetros para la tabla Nacimiento.
            modelBuilder.Entity<Nacimiento>(entity =>
            {
                entity.Property(q => q.NacimientoId).IsRequired().IsUnicode();
                entity.Property(q => q.TramiteRecienNacidoId).IsRequired();
            }
            );

            modelBuilder.Entity<TramiteDNI>(entity =>
            {
                entity.Property(q => q.TramiteDNIid).IsRequired().IsUnicode();

            }
            );
        }
    }
}
