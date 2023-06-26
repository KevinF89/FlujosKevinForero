using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Track { get; }
        IQueryable<T> NoTrack { get; }
        void Delete(IEnumerable<T> entities);


        Task<int> DeleteAsync(T entity);

        Task<int> UpdateAsync(T entity);

        Task<int> InsertAsync(T entity);


        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
