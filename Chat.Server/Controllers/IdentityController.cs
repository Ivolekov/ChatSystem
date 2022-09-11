using Chat.Server.Models;
using Chat.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController: ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IIdentityService identityService;


        public IdentityController(UserManager<User> userManager, IIdentityService identityService)
        {
            this.userManager = userManager;
            this.identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User()
            {
                UserName = model.Username
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = this.identityService.GenerateJwtToken(user.Id, user.UserName, "SOME UNICORNS CREATE THE JWT SECRET.");

            return new LoginResponseModel
            {
                Username = user.UserName,
                Token = token
            };
        }
    }
}
