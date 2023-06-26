using ApiFlujosKevinForero.Models.Flujo;
using Business.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.MappingExtensions;

namespace ApiFlujosKevinForero.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlujoController : ControllerBase
    {
        private readonly IFlujoService _flujoService;

        public FlujoController(IFlujoService flujoService)
        {
            this._flujoService = flujoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] FilterFlujo filter)
        {
            List<Data.Entities.Flujo> result = await this._flujoService.GetAsync(flujoId: filter.FlujoId, nombre: filter.Nombre);

            return this.Ok(
                new
                {
                    Data = result.ToListModels()
                }) ;
        }

        [HttpPost]
        public ActionResult Post([FromBody] FlujoModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Entities.Flujo inserResult = this._flujoService.InsertFlujoAsync(model.ToEntity()).Result;


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
        public ActionResult Put([FromBody] FlujoModel model)
        {
            if (ModelState.IsValid)
            {
                Data.Entities.Flujo updateResult = this._flujoService.UpdateFlujoAsync(model.ToEntity()).Result;


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
        public ActionResult Delete(int flujoId)
        {
            if (ModelState.IsValid)
            {
                bool updateResult = this._flujoService.DeleteflujoAsync(flujoId: flujoId).Result;


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
