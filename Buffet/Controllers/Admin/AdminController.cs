using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buffet.Controllers.Admin
{
    //bloqueio de controller para usuarios não autorizados, metodo natural do asp.net
    //so podem acessar usuarios com a devida autorização
    [Authorize]
    public class AdminController : Controller
    {
        public AdminController()
        {
        }

        
        public IActionResult Supervisao()
        {
            return View();
        }
    }
}