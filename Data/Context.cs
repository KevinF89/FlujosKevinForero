using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
   public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options)
          : base(options)
        {
        }

        public virtual DbSet<Campo> Campos { get; set; }
        public virtual DbSet<CampoRequeridoPaso> CamposRequeridosPaso { get; set; }
        public virtual DbSet<DatoUsuario> DatosUsuario { get; set; }
        public virtual DbSet<EstadoPaso> EstadosPaso { get; set; }
        public virtual DbSet<Flujo> Flujos { get; set; }
        public virtual DbSet<FlujoUsuario> FlujoUsuario { get; set; }
        public virtual DbSet<Paso> Pasos { get; set; }
        public virtual DbSet<PasoFLujoUsuario> PasosFLujoUsuario { get; set; }
        public virtual DbSet<PasoRequeridoPaso> PasosRequeridosPaso { get; set; }
        public virtual DbSet<TipoCampo> TipoCampo { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PasoRequeridoPaso>()
        .HasKey(prp => new { prp.IdPaso, prp.IdPasoRequerido });

            modelBuilder.Entity<PasoRequeridoPaso>()
                .HasOne(prp => prp.Paso)
                .WithMany(p => p.PasosRequeridos)
                .HasForeignKey(prp => prp.IdPaso);

            modelBuilder.Entity<PasoRequeridoPaso>()
                .HasOne(prp => prp.PasoRequerido)
                .WithMany()
                .HasForeignKey(prp => prp.IdPasoRequerido);


            modelBuilder.Entity<CampoRequeridoPaso>()
        .HasKey(prp => new { prp.IdPaso, prp.IdCampo });

            modelBuilder.Entity<CampoRequeridoPaso>()
                .HasOne(crp => crp.Paso)
                .WithMany(p => p.CamposRequeridos)
                .HasForeignKey(prp => prp.IdPaso);
        }
    }
}
