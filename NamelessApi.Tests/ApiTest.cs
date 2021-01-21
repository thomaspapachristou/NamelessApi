using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NamelessApi.Contracts.V1;
using NamelessApi.Contracts.V1.Requests;
using NamelessApi.Contracts.V1.Responses;
using NamelessApi.Data;
using Xunit;

namespace NamelessApi.Tests
{
    public class ApiTest
    {
        protected readonly HttpClient _httpclient;


     //   Utiliser les breakpoints pour voir pas à pas comment on se connecte au client.
        public ApiTest()
        {
            WebApplicationFactory<Startup> applicationFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DataContext));
                        services.AddDbContext<DataContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDb");

                        });
                    });
                });
            _httpclient = applicationFactory.CreateClient();
        }

     //   Test des routes venant de Contracts/Responses/ApiRoutes.cs
       [Fact]
        public async Task RouteIsOk()
        {
            HttpResponseMessage response = await _httpclient.GetAsync(ApiRoutes.Games.Get.Replace("{postId}", "1"));
        }

        //public async Task AuthenticateAsyncIsOk()
        //{
        //    _httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtBearerAsyncIsOk());
        //}

        //private async Task<string> GetJwtBearerAsyncIsOk()
        //{
        //    return null;
        //}
    }
}
