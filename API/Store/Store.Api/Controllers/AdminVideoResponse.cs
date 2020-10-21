using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Store.Shared;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminVideoResponse : JPushController
    {
        public AdminVideoResponse(UserManager<ApplicationUser> userManager) :base(userManager)
        {

        }
        [HttpPost]
        public async Task<IActionResult> Post(string userEmail,bool accepted=false)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, JPushEndPoint);

                request.Action(async d => d.Content = await SetupJPushModel(userEmail, accepted));

                using (var client = new HttpClient())
                {
                    using (var response = await client.Action(d => AddHeader(d)).SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                            return Ok();
                        else
                            return BadRequest("JPush return failure. detail:" + await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Something went wrong. Detail:{ex.Message}");
            }
        }
        private async Task<StringContent> SetupJPushModel(string userEmail, bool accepted = false)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (string.IsNullOrEmpty(user.JPushId))
                user.JPushId = "170976fa8a3330841b0";
            var jpush = new JPushModel() { audience=new Audience() { tag=new List<string>()}, message=new Message()};
            return jpush.Action(d => d.audience.tag.Add(user.JPushId))
                .Action(d => d.platform = "all")
                .Action(d => d.message.msg_content = accepted ? "Your request has beed accepted." : "Your request was rejected.")
                .Map(d => JsonSerializer.Serialize(d).Map(d => new StringContent(d, Encoding.UTF8, "application/json")));
        }
    }
}
