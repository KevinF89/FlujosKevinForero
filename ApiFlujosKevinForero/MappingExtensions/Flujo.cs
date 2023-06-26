using ApiFlujosKevinForero.Models.Flujo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.MappingExtensions
{
    public static class Flujo
    {
        public static Data.Entities.Flujo ToEntity(this FlujoModel model)
        {
            Data.Entities.Flujo cliente = new Data.Entities.Flujo
            {
                IdFLujo = model.IdFlujo,
                Nombre = model.Nombre
            };

            return cliente;
        }

        public static FlujoModel ToModel(this Data.Entities.Flujo entity)
        {
            FlujoModel cliente = new FlujoModel
            {
                IdFlujo = entity.IdFLujo,
                Nombre = entity.Nombre,
            };

            return cliente;
        }

        public static List<FlujoModel> ToListModels(this List<Data.Entities.Flujo> entities)
        {
            List<FlujoModel> models = new List<FlujoModel>();

            foreach (Data.Entities.Flujo entity in entities)
            {
                models.Add(entity.ToModel());
            }

            return models;
        }
    }
}
