using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Flujo
    {
            [Key]
            public int IdFlujo { get; set; }
            public string Nombre { get; set; }
        public virtual IEnumerable<FlujoUsuario> FlujoUsuario { get; set; } 
        public virtual IEnumerable<Paso> Paso { get; set; }
    }
}
