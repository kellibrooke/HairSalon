using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
      [HttpPost("/stylists")]
      public ActionResult StylistHome()
      {
          string stylistName = Request.Form["stylist-name"];
          Stylist newStylist = new Stylist(stylistName);
          newStylist.SaveStylist();
          List<Stylist> allStylists = Stylist.GetAllStylists();
          return View("Index", allStylists);
      }

      [HttpPost("/stylist-info")]
      public ActionResult StylistInfo()
      {
          int stylistId = int.Parse(Request.Form["stylist-info-select"]);
          Stylist selectedStylist = Stylist.FindStylist(stylistId);
          return View(selectedStylist);
      }
    }
}
