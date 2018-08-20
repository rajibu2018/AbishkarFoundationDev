using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbishkarFoundation.UI.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            var user = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            return View();
        }
    }
}