namespace MongoReception.WebApi.Helpers
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        public static class Building
        {
            public const string Specific = Root + "/building/{buildingId}";
            public const string Main = Root + "/building";
            public const string AttachExtras = Root + "/building/{buildingId}/extras";
            public const string Extras = Root + "/building/extras";
            public const string GeoLocalization = Root + "/building/locate";
        }

        public static class Room
        {
            public const string Specific = Root + "/room/{roomId}";
            public const string Main = Root + "/room";
            public const string AttachExtras = Root + "/room/{roomId}/extras";
            public const string Extras = Root + "/room/extras";
        }

        public static class User
        {
            public const string Specific = Root + "/user/{userId}";
            public const string Main = Root + "/user";
            public const string Register = Root + "/user/register";
            public const string Login = Root + "/user/login";
        }

        public static class Reservation
        {
            public const string Specific = Root + "/reservation/{reservationId}";
            public const string Main = Root + "/reservation";
            public const string Payment = Root + "/reservation/{reservationId}/pay";
        }

        public static class HandOverReport
        {
            public const string Specific = Root + "/handovereport/{handovereportId}";
            public const string Main = Root + "/handovereport";
            public const string AttachDetails = Root + "/handovereport/{handovereportId}/details";
            public const string Details = Root + "/handovereport/details";
        }
    }
}