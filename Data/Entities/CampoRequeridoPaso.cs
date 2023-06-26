using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    public class CampoRequeridoPaso
    {
        [ForeignKey("IdPaso")]
        public int IdPaso { get; set; }

        [ForeignKey("IdCampo")]
        public int IdCampo { get; set; }
        public virtual Paso Paso { get; set; }
        public virtual Campo campo { get; set; }
    }
}
