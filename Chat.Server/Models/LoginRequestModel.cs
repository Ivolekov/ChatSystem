﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Server.Models
{
    public class LoginRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
