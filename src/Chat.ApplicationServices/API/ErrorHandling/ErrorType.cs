namespace Chat.ApplicationServices.API.ErrorHandling
{
    public static class ErrorType
    {
        public const string InternalServerError = "Ło Panie, coś z tym wewnętrznym serverem nie halo";

        public const string ValidationError = "Ło Panie, coś Ty tu nawpisywał";

        public const string NotAuthenticated = "Panie? Tak szczerze, czy to naprawdę Ty?" +
            "Podej nazwisko panieńskie swojej praprababki";

        public const string Unauthorized = "Twój szal nie przejdzie";

        public const string NotFound = "-Gdzie jest keczup? -W lodówce? -Nie ma!";

        //public const string UnsupportedMediaType = "";

        public const string UnsupportedMethod = "Na Explorerze{randomeBrowserName}? Serio?";

        public const string RequestTooLarge = "Widzę, że debata w TVP się spodobała?";

        public const string TooManyRequests = "Hola Hola kolejka jest";

    }
}
