namespace CinemaApp.Data.Models
{
    public class Cinema
    {
        public Cinema()
        {
            Id = Guid.NewGuid();
            CinemaMovies = new HashSet<CinemaMovie>();
            Tickets = new HashSet<Ticket>();
        }
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
