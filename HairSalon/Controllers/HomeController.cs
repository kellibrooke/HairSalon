using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View(allStylists);
        }

        [HttpPost("/stylist-list")]
        public ActionResult UpdateList()
        {
            Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View("Index", allStylists);
        }
    }
}
