using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NamelessApi.Contracts.V1;
using NamelessApi.Contracts.V1.Requests;
using NamelessApi.Contracts.V1.Responses;
using NamelessApi.Domain;
using NamelessApi.Services;

namespace NamelessApi.Controllers.V1
{
    // On empêche toute utilisation de ce controller si la personne n'est pas authentifié et ne possède pas un token valide.
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;

        }

        // Pour être 100% Rest, nous devons bien subdiviser la template |
        // Nous utilisons des interfaces pour créer non méthodes ||


        // On affiche tous les jeux de la db
        [HttpGet(ApiRoutes.Games.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _gameService.GetGamesAsync());
        }

        // On modifie le jeu non igdb en question 
        [HttpPut(ApiRoutes.Games.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdateGameRequest request)
        {
            Game post = new Game
            {
                Id = postId,
                Name = request.Name
            };

            bool updated = await _gameService.UpdateGameAsync(post);
            if (updated)
            {

                return Ok(post);
            }

            return NotFound();
        }

        // On supprime le jeu non igdb en question 
        [HttpDelete(ApiRoutes.Games.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            bool deleted = await _gameService.DeleteGameAsync(postId);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }


        [HttpGet(ApiRoutes.Games.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid postId)
        {
            Game post = await _gameService.GetGameByIdAsync(postId);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost(ApiRoutes.Games.Create)]
        public async Task<IActionResult> Create([FromBody] CreateGameRequest postRequest)
        {

            Game post = new Game {Name = postRequest.Name};

            await _gameService.CreateGameAsync(post);
             
            string baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string locationUri = baseUrl + "/" + ApiRoutes.Games.Get.Replace("{postId}", post.Id.ToString());

            GameReponse response = new GameReponse {Id = post.Id};

            return Created(locationUri, post);
        }


    }
}
