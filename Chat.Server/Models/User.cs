using Microsoft.AspNetCore.Identity;

namespace Chat.Server.Models
{
    public class User : IdentityUser
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
