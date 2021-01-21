using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using NamelessApi.Contracts.V1;
using NamelessApi.Contracts.V1.Requests;
using NamelessApi.Contracts.V1.Responses;
using NamelessApi.Services;

namespace NamelessApi.Controllers.V1
{
    public class UserController : Controller
    {
        // Attention ! Toujours la même séparation que dans Game, on reste dans la même infrastructure pour
        // Pour un côté plus R E S T F U L L (ça donne envie de dormir vu l'heure)

        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(ApiRoutes.User.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {

            // Errreur EmailAttribut from UserRegistration
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthenticationFailedResponse
                {
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))

                });
            }

            var authResponse = await _userService.RegisterAsync(request.Email, request.Username, request.Password);

            if (!authResponse.Success)
            {
                // On get les erreurs du auth failed response
                return BadRequest(new AuthenticationFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthenticationSuccessResponse
            {
                Token = authResponse.Token
            });
        }

        [HttpPost(ApiRoutes.User.Login)]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _userService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                // On get les erreurs du auth failed de response
                return BadRequest(new AuthenticationFailedResponse
                {
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthenticationSuccessResponse
            {
                Token = authResponse.Token
            });
        }

    }
}
