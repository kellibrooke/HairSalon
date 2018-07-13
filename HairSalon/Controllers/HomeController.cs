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
            string stylistName = Request.Form["stylist-name"];
            Stylist newStylist = new Stylist(stylistName);
            newStylist.SaveStylist();
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View("Index", allStylists);
        }
    }
}
