using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
    public class ServiceController : Controller
    {
      [HttpGet("/services")]
      public IActionResult ViewAllServices()
      {
          return View(Service.GetAllServices());
      }
    }
}
