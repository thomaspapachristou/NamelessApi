using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NamelessApi.Domain;

namespace NamelessApi.Services
{
    public interface  IGameService
    {

        Task<List<Game>> GetGamesAsync();

        Task<Game> GetGameByIdAsync(Guid gameId);

        Task<bool> CreateGameAsync(Game game);

        Task<bool> UpdateGameAsync(Game gameToUpdate);

        Task<bool> DeleteGameAsync(Guid gameId);

    }
}
