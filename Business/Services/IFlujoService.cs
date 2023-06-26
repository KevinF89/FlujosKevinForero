using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IFlujoService
    {
        Task<Flujo> InsertFlujoAsync(Flujo flujo);
         Task<bool> DeleteflujoAsync(int flujoId);
        Task<Flujo> UpdateFlujoAsync(Flujo flujo);
        Task<List<Flujo>> GetAsync(int? flujoId = null, string nombre = null, bool tracking = false);
         Task<Flujo> GetByIdAsync(int? flujoId = null, bool tracking = false);
        IQueryable<Flujo> Query(int? flujoId = null, string nombre = null, bool tracking = false);
    }
}
