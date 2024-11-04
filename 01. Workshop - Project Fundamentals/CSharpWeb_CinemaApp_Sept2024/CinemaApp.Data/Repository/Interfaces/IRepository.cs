namespace CinemaApp.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);
        Task<TType> GetByIdAsync(TId id);
        Task<TType> GetByIdAsync(params TId[] id);

        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();

        IQueryable<TType> GetAllAttached();

        void Add(TType entity);
        Task AddAsync(TType entity);

        void AddRange(TType[] entities);
        Task AddRangeAsync(TType[] entities);

        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);

        bool Update(TType entity);
        Task<bool> UpdateAsync(TType entity);
    }
}
