using NamelessApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamelessApi.Services
{
    public class GameServiceIgdb : IGameIgdb
    {

        private readonly DataContext _dataContext;

        public GameServiceIgdb(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        


    }
}
