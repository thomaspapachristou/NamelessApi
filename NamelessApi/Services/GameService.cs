using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NamelessApi.Data;
using NamelessApi.Domain;

namespace NamelessApi.Services
{
    public class GameService : IGameService
    {

        // A faire plus tard : modifier tous les noms en asynchr

        private readonly DataContext _dataContext;

        public GameService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Game>> GetGamesAsync()
        {
            return await _dataContext.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(Guid gameId)
        {
            return await _dataContext.Games.SingleOrDefaultAsync(x => x.Id == gameId);

        }

        public async Task<bool> CreateGameAsync(Game game)
        {
            await _dataContext.Games.AddAsync(game);
            int created = await _dataContext.SaveChangesAsync();
            return created > 0; 
        }

        public async Task<bool> UpdateGameAsync(Game gameToUpdate)
        {

            _dataContext.Games.Update(gameToUpdate);
            int updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteGameAsync(Guid gameId)
        {
            Game game = await GetGameByIdAsync(gameId);

            if (game == null)
            {
                return false;
            }
            _dataContext.Games.Remove(game);
             int deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
