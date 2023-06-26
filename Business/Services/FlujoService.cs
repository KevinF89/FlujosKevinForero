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
    public class FlujoService : IService
    {
        private readonly IBaseRepository<Flujo> _repositoryFlujo;

        public FlujoService(IBaseRepository<Flujo> repositoryFlujo)
        {
            this._repositoryFlujo = repositoryFlujo;
        }

        public async Task<Flujo> InsertFlujoAsync(Flujo flujo)
        {
            await this._repositoryFlujo.InsertAsync(flujo);
            return flujo;
        }

        public async Task<bool> DeleteflujoAsync(int flujoId)
        {
            bool result = false;
            Flujo flujo = this.Query(flujoId: flujoId, tracking: true).FirstOrDefault();

            result = await this._repositoryFlujo.DeleteAsync(flujo) > 0 ? true : false;

            return result;
        }

        public async Task<Flujo> UpdateFlujoAsync(Flujo flujo)
        {
            Flujo updateFlujo = this.Query(flujoId: flujo.IdFlujo, tracking: true).FirstOrDefault();

            updateFlujo.Nombre = flujo.Nombre;

            await this._repositoryFlujo.UpdateAsync(updateFlujo);

            return flujo;
        }

        public async Task<List<Flujo>> GetAsync(int? flujoId = null, string nombre = null, bool tracking = false)
        {
            List<Flujo> pagedList = await this.Query(flujoId: flujoId, nombre: nombre, tracking: tracking).ToListAsync();

            return pagedList;
        }


        public async Task<Flujo> GetByIdAsync(int? flujoId = null, bool tracking = false)
        {
            return await this.Query(flujoId: flujoId, tracking: tracking).FirstOrDefaultAsync();
        }

        public IQueryable<Flujo> Query(int? flujoId = null, string nombre = null, bool tracking = false)
        {
            IQueryable<Flujo> query = tracking ? this._repositoryFlujo.Track : this._repositoryFlujo.NoTrack;

            if (flujoId.HasValue)
            {
                query = query.Where(w => w.IdFlujo.Equals(flujoId.Value));
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(w => w.Nombre.Equals(nombre));
            }

            query = query.OrderBy(ob => ob.IdFlujo);

            return query;
        }
    }
}
