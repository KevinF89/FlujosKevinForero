using ApiFlujosKevinForero.MappingExtensions;
using ApiFlujosKevinForero.Models.Paso;
using Business.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.MappingExtensions;

namespace ApiPasosKevinForero.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PasoController : ControllerBase
    {
        private readonly PasoService _pasoService;

        public PasoController(IService pasoService)
        {
            this._pasoService = (PasoService)pasoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] PasoFilter filter)
        {
            List<Data.Entities.Paso> result = await this._pasoService.GetAsync(pasoId: filter.IdPaso, nombre: filter.Nombre, flujoId: filter.IdFlujo);

            return this.Ok(
                new
                {
                    Data = result.ToListModels()
                }) ;
        }

        [HttpPost]
        public ActionResult Post([FromBody] PasoSaveModel model)
        {
            if (ModelState.IsValid)
            {
                 Data.Entities.Paso inserResult = this._pasoService.InsertPasoAsync(model.ToEntity(), camposRequeridos: model.CamposRequeridos, pasosRequeridos: model.PasosRequeridos).Result;


                return this.Ok(
                    new
                    {
                        Data = inserResult.ToModel()
                    });
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] PasoSaveModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Entities.Paso updateResult = this._pasoService.UpdatePasoAsync(model.ToEntity(), camposRequeridos: model.CamposRequeridos, pasosRequeridos:  model.PasosRequeridos).Result;


                return this.Ok(
                    new
                    {
                        Data = updateResult.ToModel(),
                    });
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public ActionResult Delete(int pasoId)
        {
            if (ModelState.IsValid)
            {
                bool updateResult = this._pasoService.DeletepasoAsync(pasoId: pasoId).Result;


                return this.Ok(
                    new
                    {
                        Data = updateResult
                    });
            }
            else
            {
                return this.BadRequest(ModelState);
            }
        }
    }
}
