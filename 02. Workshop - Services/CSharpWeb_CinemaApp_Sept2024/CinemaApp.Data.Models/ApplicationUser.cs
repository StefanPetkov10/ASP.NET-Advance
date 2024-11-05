using Microsoft.AspNetCore.Identity;

namespace CinemaApp.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.ApplicationUserMovies = new HashSet<ApplicationUserMovie>();
            this.Tickets = new HashSet<Ticket>();
        }

        public virtual ICollection<ApplicationUserMovie> ApplicationUserMovies { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
