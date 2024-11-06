using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Data
{
    public class ManagerService : BaseService, IManagerService
    {
        private readonly IRepository<Manager, Guid> managerRepository;

        public ManagerService(IRepository<Manager, Guid> managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public async Task<bool> IsUserManagerAsync(string? userId)
        {
            //Not a valid use case, but we write defensive programming
            if (String.IsNullOrWhiteSpace(userId))
            {
                return false;
            }

            bool result = await this.managerRepository
                .GetAllAttached()
                .AnyAsync(m => m.UserId.ToString().ToLower() == userId.ToLower());

            return result;
        }
    }
}
