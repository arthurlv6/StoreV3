using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Store.Shared;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVideoRequest : JPushController
    {
        public UserVideoRequest(UserManager<ApplicationUser> userManager):base(userManager)
        {

        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, JPushEndPoint);
                request.Action(async d => d.Content = await SetupJPushModel());
                using (var client = new HttpClient())
                {
                    using (var response = await client.Action(d => AddHeader(d)).SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                            return Ok();
                        else
                            return BadRequest("JPush return failure.");
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Something went wrong. Detail:{ex.Message}");
            }
        }
        private async Task<StringContent> SetupJPushModel()
        {
            var clientServer= await _userManager.Users.FirstAsync(d => d.IsClientServer);
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            var jpush = new JPushModel() { audience = new Audience() { tag = new List<string>() }, message = new Message() };
            return jpush.Action(d => d.audience.tag.Add(clientServer.JPushId))
                .Action(d => d.platform = "all")
                .Action(d => d.message.msg_content =  $"User {User.Identity.Name} sent a video request." )
                .Map(d => JsonSerializer.Serialize(d).Map(d => new StringContent(d, Encoding.UTF8, "application/json")));
        }

    }
}
