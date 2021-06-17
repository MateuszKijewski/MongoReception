﻿namespace MongoReception.WebApi.Helpers
{
    public static class ApiRoutes
    {
        private const string Root = "api";

        public static class Building
        {
            public const string Specific = Root + "/building/{buildingId}";
            public const string Main = Root + "/building";
        }

        public static class Room
        {
            public const string Specific = Root + "/room/{roomId}";
            public const string Main = Root + "/room";
        }

        public static class User
        {            
            public const string Register = Root + "/user/register";
            public const string Login = Root + "/user/login";
        }
    }
}