using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Paso
    {
        [Key]
        public int IdPaso { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("IdFLujo")]
        public int IdFLujo { get; set; }
        public int Posicion { get; set; }
        public virtual Flujo Flujo { get; set; }
        public virtual IEnumerable<CampoRequeridoPaso> CamposRequeridos { get; set; }
        public virtual IEnumerable<PasoRequeridoPaso> PasosRequeridos { get; set; }
        public virtual IEnumerable<PasoRequeridoPaso> PasosDependientes { get; set; }

    }
}
