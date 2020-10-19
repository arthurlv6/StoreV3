using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JPushController : ControllerBase
    {
        protected readonly UserManager<ApplicationUser> _userManager;

        public string JPushEndPoint { get; private set; }
        public string AppKey { get; private set; }
        public string  MasterSecret { get; private set; }
        public JPushController(UserManager<ApplicationUser> userManager)
        {
            JPushEndPoint = "https://api.jpush.cn/v3/push";
            AppKey = "";
            MasterSecret = "";
            _userManager = userManager;
        }
        protected string GetToken()
        {
            byte[] bytes = Encoding.ASCII.GetBytes($"{AppKey}:{MasterSecret}");
            return Convert.ToBase64String(bytes);
        }
        protected HttpClient AddHeader(HttpClient client)
        {
            if (!client.DefaultRequestHeaders.Contains("Authorization"))
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {GetToken()}");
            else
            {

                var auth = client.DefaultRequestHeaders.FirstOrDefault(d => d.Key == "Authorization");
                client.DefaultRequestHeaders.Remove("Authorization");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {GetToken()}");
            }
            return client;
        }
    }
}
