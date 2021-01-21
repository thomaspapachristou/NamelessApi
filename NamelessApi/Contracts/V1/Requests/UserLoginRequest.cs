using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamelessApi.Contracts.V1.Requests
{
    public class UserLoginRequest
    {
        // A ajouter dans la méthode login - Voir pour une méthode sans atribut
        //[EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
