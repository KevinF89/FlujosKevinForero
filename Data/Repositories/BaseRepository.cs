using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.BaseRepositories
{

    public class BaseRepository<T>: IBaseRepository<T> where T : class
    {

        private readonly Context context;

        private DbSet<T> entities;

        public BaseRepository(Context context)
        {
            this.context = context;
        }

        public IQueryable<T> Track
        {
            get
            {
                return this.Entities;
            }
        }


        public IQueryable<T> NoTrack
        {
            get
            {
                return this.Entities.AsNoTracking();
            }
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    this.entities = this.context.Set<T>();
                }

                return this.entities;
            }
        }
        public void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            while (entities.Count() > 0)
            {
                this.context.Entry(entities.ElementAt(0)).State = EntityState.Deleted;
            }

            this.context.SaveChanges();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.context.Entry(entity).State = EntityState.Deleted;
            this.Entities.Remove(entity);
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.context.Entry(entity).State = EntityState.Modified;
            return await this.context.SaveChangesAsync();
        }

        public async Task<int> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            this.Entities.Add(entity);
            return await this.context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }

    }
}
