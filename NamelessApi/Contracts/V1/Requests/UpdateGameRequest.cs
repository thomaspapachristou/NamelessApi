using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamelessApi.Contracts.V1.Requests
{

    // Pas besoin d'un Guid car on a seulement besoin d'update le nom
    public class UpdateGameRequest
    {
        public string Name { get; set; }
    }
}
