using Chat.Server.Data;
using Chat.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {
        ChatDBContext context;
        public UsersController(ChatDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await this.context.Users.ToArrayAsync());
        }
    }
}
