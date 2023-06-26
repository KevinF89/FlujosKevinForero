using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class PasoRequeridoPaso
    {
        public int IdPaso { get; set; }
        public int IdPasoRequerido { get; set; }
        public virtual Paso Paso { get; set; }
        public virtual Paso PasoRequerido { get; set; }
    }
}
