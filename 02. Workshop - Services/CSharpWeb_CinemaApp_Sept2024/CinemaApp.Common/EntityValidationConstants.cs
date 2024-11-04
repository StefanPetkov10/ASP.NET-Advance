namespace CinemaApp.Common
{
    public class EntityValidationConstants
    {
        public static class Movie
        {
            public const int TitleMaxLength = 50;
            public const int GenreMaxLength = 20;
            public const int GenreMinLength = 5;
            public const int DurationMinValue = 1;
            public const int DurationMaxValue = 999;
            public const string ReleaseDateFormat = "MM/yyyy";
            public const int DirectorMinLength = 10;
            public const int DirectorMaxLength = 80;
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
        }

        public static class Cinema
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
            public const int LocationMaxLength = 85;
            public const int LocationMinLength = 3;

        }
    }
}
