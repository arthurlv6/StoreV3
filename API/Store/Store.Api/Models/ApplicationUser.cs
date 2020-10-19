using Microsoft.AspNetCore.Identity;

namespace Store.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string JPushId { get; set; }
        public bool IsClientServer { get; set; } = false;
    }
}
