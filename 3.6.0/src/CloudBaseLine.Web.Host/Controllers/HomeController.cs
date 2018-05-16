using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudBaseLine.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CloudBaseLine.Web.Host.Controllers
{
    public class HomeController : CloudBaseLineControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}