﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoneyExchange.Controllers
{
    public class LoginController : Controller
    {
        // GET: /<controller>/
        public string Index( string user )
        {
            if(user == "admin"){
                return "Logged";
            }
            throw new NotImplementedException("Please create a test first");
        }
    }
}
