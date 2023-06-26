using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Entities;
using System.Threading.Tasks;
using System.Linq;
using Data.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using Data.Repositories;

namespace Business.Services
{
    public class PasoService : IService
    {
        private readonly IBaseRepository<Paso> _repositoryPaso;
        private readonly IBaseRepository<CampoRequeridoPaso> _repositoryCampoRequerido;
        private readonly IBaseRepository<PasoRequeridoPaso> _repositoryPasoRequerido;

        public PasoService(IBaseRepository<Paso> repositoryPaso, IBaseRepository<CampoRequeridoPaso> repositoryCampoRequerido, IBaseRepository<PasoRequeridoPaso> repositoryPasoRequerido)
        {
            this._repositoryPaso = repositoryPaso;
            this._repositoryCampoRequerido = repositoryCampoRequerido;
            this._repositoryPasoRequerido = repositoryPasoRequerido;
        }

        public async Task<Paso> InsertPasoAsync(Paso paso, int[] camposRequeridos = null, int[] pasosRequeridos = null)
        {
            await this._repositoryPaso.InsertAsync(paso);
            await this.SaveRqueridos(paso, camposRequeridos, pasosRequeridos);

            return paso;
        }

        public async Task<bool> DeletepasoAsync(int pasoId)
        {
            bool result = false;
            Paso paso = this.Query(pasoId: pasoId, tracking: true).FirstOrDefault();
            await DeleteRequeridos(paso);
            result = await this._repositoryPaso.DeleteAsync(paso) > 0 ? true : false;

            return result;
        }

        public async Task<Paso> UpdatePasoAsync(Paso paso, int[] camposRequeridos = null, int[] pasosRequeridos = null)
        {
            Paso updatePaso = this.Query(pasoId: paso.IdPaso, tracking: true).FirstOrDefault();

            updatePaso.Nombre = paso.Nombre;
            updatePaso.Posicion = paso.Posicion;

            await this._repositoryPaso.UpdateAsync(updatePaso);
            await this._repositoryPaso.SaveChangesAsync();
            await DeleteRequeridos(updatePaso);
            await this.SaveRqueridos(updatePaso, camposRequeridos, pasosRequeridos);


            return paso;
        }

        public async Task<List<Paso>> GetAsync(int? pasoId = null, string nombre = null, int? flujoId = null, bool tracking = false)
        {
            List<Paso> pagedList = await this.Query(pasoId: pasoId, nombre: nombre, flujoId: flujoId, tracking: tracking).ToListAsync();

            return pagedList;
        }


        public async Task<Paso> GetByIdAsync(int? pasoId = null, bool tracking = false)
        {
            return await this.Query(pasoId: pasoId, tracking: tracking).FirstOrDefaultAsync();
        }

        public IQueryable<Paso> Query(int? pasoId = null, string nombre = null, int? flujoId = null, bool tracking = false)
        {
            IQueryable<Paso> query = tracking ? this._repositoryPaso.Track : this._repositoryPaso.NoTrack;

            query = query.Include(i => i.PasosRequeridos);
            query = query.Include("PasosRequeridos.PasoRequerido");

            if (pasoId.HasValue)
            {
                query = query.Where(w => w.IdPaso.Equals(pasoId.Value));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(w => w.Nombre.Equals(nombre));
            }

            if (flujoId.HasValue)
            {
                query = query.Where(w => w.IdFlujo.Equals(flujoId.Value));
            }

            query = query.OrderBy(ob => ob.IdFlujo);

            return query;
        }

        private async Task<bool> DeleteRequeridos(Paso paso)
        {
            List<CampoRequeridoPaso> campos = paso.CamposRequeridos != null ? paso.CamposRequeridos.ToList() : null;
            List<PasoRequeridoPaso> pasos = paso.PasosRequeridos != null ? paso.PasosRequeridos.ToList(): null;

            if (campos != null && campos.Count > 0)
            {
                foreach (CampoRequeridoPaso campo in campos)
                {
                    await this._repositoryCampoRequerido.DeleteAsync(campo);
                }
            }

            if (pasos != null && pasos.Count > 0)
            {
                foreach (PasoRequeridoPaso pasoRequerido in pasos)
                {
                    await this._repositoryPasoRequerido.DeleteAsync(pasoRequerido);
                }
            }

            return true;
        }

        private async Task<bool> SaveRqueridos(Paso paso, int[] camposRequeridos, int[] pasosRequeridos)
        {
            if (camposRequeridos != null && camposRequeridos.Length > 0)
            {
                List<CampoRequeridoPaso> campos = camposRequeridos.Select(s => new CampoRequeridoPaso { IdPaso = paso.IdPaso, IdCampo = s }).ToList();
                foreach (CampoRequeridoPaso campo in campos)
                {
                    await this._repositoryCampoRequerido.InsertAsync(campo);
                }
            }

            if ( pasosRequeridos !=null &&  pasosRequeridos.Length > 0)
            {
                List<PasoRequeridoPaso> pasos = pasosRequeridos.Select(s => new PasoRequeridoPaso { IdPaso = paso.IdPaso, IdPasoRequerido = s }).ToList();
                foreach (PasoRequeridoPaso pasoRequerido in pasos)
                {
                    await this._repositoryPasoRequerido.InsertAsync(pasoRequerido);
                }
            }

            return true;
        }
    }
}
