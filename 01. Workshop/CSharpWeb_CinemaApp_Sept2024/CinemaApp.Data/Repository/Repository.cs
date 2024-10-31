using CinemaApp.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Repository
{
    public class Repository<TType, TId> : IRepository<TType, TId>
        where TType : class
    {

        private readonly CinemaDbContext dbContext;
        private readonly DbSet<TType> dbSet;

        public Repository(CinemaDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TType>();
        }

        public TType GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<TType> GetByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TType> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TType>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Add(TType entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TType entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftDeleteAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public bool Update(TType entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TType entity)
        {
            throw new NotImplementedException();
        }
    }
}
