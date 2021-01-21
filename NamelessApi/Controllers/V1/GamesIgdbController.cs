using Microsoft.AspNetCore.Mvc;
using NamelessApi.Data;
using System;
using System.Threading.Tasks;
using IGDB;
using IGDB.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using NamelessApi.Contracts.V1;


namespace NamelessApi.Controllers.V1
{

    // A refactoriser sans wrapper

   [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GamesIgdbController : Controller
    {
        private readonly ITokenStore _tokenStore;
        private readonly DataContext _datacontext;

        public GamesIgdbController(DataContext datacontext, ITokenStore tokenStore)
        {
            _datacontext = datacontext;
            _tokenStore = tokenStore;
        }


        [HttpGet(ApiRoutes.GamesIgdb.Getall)]
        public async Task<IActionResult> GetAllIgbdb()
        {

            // A REFACTORISER
            IGDBClient igdbAuth = new IGDBClient(
                Environment.GetEnvironmentVariable("IGDB_CLIENT_ID"),
                Environment.GetEnvironmentVariable("IGDB_CLIENT_SECRET")
            );

            Game[] queryGamesIgdb =
                await igdbAuth.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields id,name; where id = 0 & status = 0; sort rating desc; limit = 10;");

            return Ok(new JsonResult(queryGamesIgdb));
        }   

    }
}
