using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Campo
    {
        [Key]
        public int IdCampo { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("IdTipoCampo")]
        public int IdTipoCampo { get; set; }
        public bool Requerido { get; set; }
        public virtual TipoCampo TipoCampo { get; set; }
    }
}
