using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Services
{
    public interface IIdentityService
    {
        public string GenerateJwtToken(string userId, string username, string secret);
    }
}
