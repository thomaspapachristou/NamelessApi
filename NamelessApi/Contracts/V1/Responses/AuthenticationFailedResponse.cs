using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamelessApi.Contracts.V1.Responses
{
    public class AuthenticationFailedResponse
    {

        public IEnumerable<string> Errors { get; set; }

    }
}
