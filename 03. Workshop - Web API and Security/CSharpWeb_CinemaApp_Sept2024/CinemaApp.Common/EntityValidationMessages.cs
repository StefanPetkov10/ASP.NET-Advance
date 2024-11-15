namespace CinemaApp.Common
{
    public static class EntityValidationMessages
    {
        public static class Movie
        {
            public const string TitleRequiredMessage = "Movie title is required!";
            public const string TitleMaxLengthMessage = "Movie title is too long";
            public const string GenreRequiredMessage = "Movie genre is required!";
            public const string ReleaseDateRequiredMessage = "Release date is required in format MM/yyyy!";
            public const string DirectorRequiredMessage = "Director name is required!";
            public const string DurationRangeMessage = "Plece specify movie duration!";
        }
    }
}
