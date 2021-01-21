using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamelessApi.Domain
{
    public class GameIgdb
    {

        public string Id {get;set;}

        public string Name { get; set; }

        public string Storyline { get; set; }

        public User User { get; set; }

    }
}
