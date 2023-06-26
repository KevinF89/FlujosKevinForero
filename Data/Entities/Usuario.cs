using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public virtual IEnumerable<DatoUsuario> DatosUsuario { get; set; }
        public virtual IEnumerable<FlujoUsuario> FlujoUsuario { get; set; }
    }
}
