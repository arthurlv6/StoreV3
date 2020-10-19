using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string JPushId { get; set; }
        public bool IsClientServer { get; set; } = false;
    }
}
