using Chat.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Data
{
    public class ChatDBContext:IdentityDbContext<User>
    {
        public ChatDBContext(DbContextOptions<ChatDBContext> options):base(options)
        {

        }
    }
}
