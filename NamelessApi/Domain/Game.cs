using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NamelessApi.Domain
{
 
    //[Table("Game")]
    public class Game
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
