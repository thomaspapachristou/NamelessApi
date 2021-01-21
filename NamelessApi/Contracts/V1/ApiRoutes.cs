using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamelessApi.Contracts.V1
{
    public class ApiRoutes
    {
        // Pour pouvoir rendre l'Api Rest modulaire, nous créons un système de versionning et nous configurons les routes.

        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;


        // Pour un côté plus clean, nous créons les routes dans un fichier à part afin qu'il soit plus lisible et plus modulable.
        
        // Partie Crud des jeux de l'Api
        public static class Games
        {
            public const string GetAll = Base + "/games";

            public const string Update = Base + "/games/{postId}";

            public const string Delete = Base + "/games/{postId}";

            public const string Get = Base + "/games/{postId}";

            public const string Create = Base + "/games";

        }

        // Partie Api jeu Igdb request

        public static class GamesIgdb
        {
            public const string Getall = Base + "/gamesigdb";

            public const string GetByName = Base + "/gamesigdb";
        }


        // Partie utilisateur claims
        public static class User
        {
            public const string Login = Base + "/user/login";

            public const string Register = Base + "/user/register";

        }


    }
}
