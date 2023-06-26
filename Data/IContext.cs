using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IContext
    {
         DbSet<Campo> Campos { get; set; }
         DbSet<CampoRequeridoPaso> CamposRequeridosPaso { get; set; }
         DbSet<DatoUsuario> DatosUsuario { get; set; }
         DbSet<EstadoPaso> EstadosPaso { get; set; }
         DbSet<Flujo> Flujos { get; set; }
         DbSet<FlujoUsuario> FlujoUsuario { get; set; }
         DbSet<Paso> Pasos { get; set; }
         DbSet<PasoFLujoUsuario> PasosFLujoUsuario { get; set; }
         DbSet<PasoRequeridoPaso> PasosRequeridosPaso { get; set; }
         DbSet<TipoCampo> TipoCampo { get; set; }
         DbSet<Usuario> Usuarios { get; set; }
    }
}
