using ApiFlujosKevinForero.Models.Paso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFlujosKevinForero.MappingExtensions
{
    public static class Paso
    {
        public static Data.Entities.Paso ToEntity(this PasoSaveModel model)
        {
            Data.Entities.Paso cliente = new Data.Entities.Paso
            {
                IdPaso = model.IdPaso,
                Nombre = model.Nombre,
                IdFlujo = model.IdFlujo,
                Posicion = model.Posicion
            };

            return cliente;
        }

        public static PasoModel ToModel(this Data.Entities.Paso entity)
        {
            PasoModel cliente = new PasoModel
            {
                IdPaso = entity.IdPaso,
                Nombre = entity.Nombre,
                IdFlujo= entity.IdFlujo,
                Posicion = entity.Posicion,
                CamposRequeridos = entity.CamposRequeridos != null ? entity.CamposRequeridos.Select(s => s.IdCampo).ToArray() : null,
                PasosRequeridos = entity.PasosRequeridos != null ? entity.PasosRequeridos.Select(s => s.IdPasoRequerido).ToArray(): null
            };

            return cliente;
        }

        public static List<PasoModel> ToListModels(this List<Data.Entities.Paso> entities)
        {
            List<PasoModel> models = new List<PasoModel>();

            foreach (Data.Entities.Paso entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
