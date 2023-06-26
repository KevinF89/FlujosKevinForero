using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class PasoFLujoUsuario
    {
        [Key]
        public int IdPasoFlujoUsuario { get; set; }
        [ForeignKey("IdFlujoUsuario")]
        public int IdFlujoUsuario { get; set; }
        [ForeignKey("IdPaso")]
        public int IdPaso { get; set; }
        [ForeignKey("IdEstado")]
        public int IdEstado { get; set; }

        public virtual FlujoUsuario FlujoUsuario { get; set; }
        public virtual Paso Paso { get; set; }
        public virtual EstadoPaso Estado { get; set; }
    }
}
