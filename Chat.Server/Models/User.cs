﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Models
{
    public class User:IdentityUser
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
