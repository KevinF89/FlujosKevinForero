using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFlujosKevinForero.Models.Paso
{
    public class PasoFilter
    {
        public int? IdPaso { get; set; }
        public string Nombre { get; set; }
        public int? IdFlujo { get; set; }
    }
}
