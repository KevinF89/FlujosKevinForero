using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFlujosKevinForero.Models.Paso
{
    public class PasoSaveModel
    {
        public int IdPaso { get; set; }
        public string Nombre { get; set; }
        public int IdFlujo { get; set; }
        public int Posicion { get; set; }
        public int[] CamposRequeridos { get; set; }
        public int[] PasosRequeridos { get; set; }
    }
}
