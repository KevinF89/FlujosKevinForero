using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class TipoCampo
    {
        [Key]
        public int IdTipoCampo { get; set; }
        public string Nombre { get; set; }
        public string Regex {get; set;}
    }
}
