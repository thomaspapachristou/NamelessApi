using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NamelessApi.Contracts.V1;
using NamelessApi.Domain;
using Xunit;

namespace NamelessApi.Tests
{
   // public class GamesControllerTests : ApiTest
  //  {
        //[Fact]  
        //public async Task GetAllReturnsEmptyArrayIsOk()
        //{
        //    //Arrange
        //    await AuthenticateAsyncIsOk();

        //    //Fact
        //    HttpResponseMessage response = await _httpclient.GetAsync(ApiRoutes.Games.GetAll);

        //    //Assert = 
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);
        //    (await response.Content.ReadFromJsonAsync<List<Game>>()).Should().BeEmpty();
        //}

   // }
}
