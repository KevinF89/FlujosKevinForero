using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class DatoUsuario
    {
        [Key]
        public int IdDatoUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("IdCampo")]
        public int IdCampo { get; set; }
        public string Valor { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Campo Campo { get; set; }
    }
}
