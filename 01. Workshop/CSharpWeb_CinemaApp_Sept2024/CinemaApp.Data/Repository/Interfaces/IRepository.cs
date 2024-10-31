namespace CinemaApp.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);
        Task<TType> GetByIdAsync(TId id);

        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();

        void Add(TType entity);
        Task AddAsync(TType entity);


        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);

        bool SoftDelete(TId id);
        Task<bool> SoftDeleteAsync(TId id);

        bool Update(TType entity);
        Task<bool> UpdateAsync(TType entity);
    }
}
