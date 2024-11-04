using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.ApplicationUserMovies = new HashSet<ApplicationUserMovie>();
        }

        public virtual ICollection<ApplicationUserMovie> ApplicationUserMovies { get; set; }
    }
}
