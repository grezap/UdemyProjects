using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GraniteHouseUdemy.Areas.Admin.Controllers
{
    public class ProductTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}