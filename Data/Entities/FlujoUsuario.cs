using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class FlujoUsuario
    {
        [Key]
        public int IdFlujoUsuario { get; set; }
        [ForeignKey("IdFlujo")]
        public int IdFlujo { get; set; }
        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }

        public virtual Flujo Flujo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
