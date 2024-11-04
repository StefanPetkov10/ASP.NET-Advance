using CinemaApp.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Repository
{
    public class BaseRepository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {

        private readonly CinemaDbContext dbContext;
        private readonly DbSet<TType> dbSet;

        public BaseRepository(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TType>();
        }

        public TType GetById(TId id)
        {
            TType entity = this.dbSet
                .Find(id);

            return entity;
        }

        public async Task<TType> GetByIdAsync(TId id)
        {
            TType entity = await this.dbSet
                .FindAsync(id);

            return entity;
        }
        public async Task<TType> GetByIdAsync(params TId[] id)
        {
            //Temp patch... Fix ASAP
            TType entity = await this.dbSet
                .FindAsync(id[0], id[1]);

            return entity;
        }

        public IEnumerable<TType> GetAll() => this.dbSet.ToArray();

        public async Task<IEnumerable<TType>> GetAllAsync() =>
            await this.dbSet.ToArrayAsync();

        public IQueryable<TType> GetAllAttached() => this.dbSet.AsQueryable();

        public void Add(TType entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }

        public async Task AddAsync(TType entity)
        {
            await this.dbSet.AddAsync(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public void AddRange(TType[] entities)
        {
            this.dbSet.AddRange(entities);
            this.dbContext.SaveChanges();
        }

        public async Task AddRangeAsync(TType[] entities)
        {
            await this.AddRangeAsync(entities);
            await this.dbContext.SaveChangesAsync();
        }

        public bool Delete(TId id)
        {
            TType entity = this.GetById(id);
            if (entity == null)
            {
                return false;
            }

            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteAsync(TId id)
        {
            TType entity = await this.GetByIdAsync(id);
            if (entity == null)
            {
                return false;
            }

            this.dbSet.Remove(entity);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public bool Update(TType entity)
        {
            try
            {
                this.dbSet.Attach(entity);
                this.dbContext.Entry(entity).State = EntityState.Modified;
                this.dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(TType entity)
        {
            try
            {
                this.dbSet.Attach(entity);
                this.dbContext.Entry(entity).State = EntityState.Modified;
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
