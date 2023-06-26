using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class EstadoPaso
    {
        [Key]
        public int IdEstadoPaso { get; set; }
        public string Nombre { get; set; }
    }
}
