using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
      [HttpGet("/stylists")]
      public IActionResult ViewAllStylists()
      {
          List<Stylist> allStylists = Stylist.GetAllStylists();
          return View(allStylists);
      }

      [HttpGet("/stylists/new")]
      public IActionResult CreateStylistForm()
      {
          return View();
      }

      [HttpPost("/stylists/new")]
      public IActionResult CreateStylist(string stylistName)
      {
          Stylist newStylist = new Stylist(stylistName);
          newStylist.SaveStylist();
          return RedirectToAction("ViewAllStylists");
      }

      [HttpGet("/stylists/{id}")]
      public ActionResult StylistInfo(int id)
      {
          Stylist selectedStylist = Stylist.FindStylist(id);
          return View(selectedStylist);
      }
    }
}
