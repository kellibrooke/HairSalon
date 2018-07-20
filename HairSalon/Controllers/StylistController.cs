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

      [HttpGet("/stylists/{id}/addclient")]
      public IActionResult AddNewClient()
      {
          return View("StylistInfo");
      }

      [HttpPost("/stylists/{id}/addclient")]
      public IActionResult AddClient(int id, int addedClientId)
      {
          Stylist selectedStylist = Stylist.FindStylist(id);
          Client selectedClient = Client.FindClient(addedClientId);
          selectedStylist.AddClient(selectedClient);
          return RedirectToAction("StylistInfo");
      }

      [HttpGet("/stylists/{id}/addservice")]
      public IActionResult AddNewService()
      {
          return View("StylistInfo");
      }

      [HttpPost("/stylists/{id}/addservice")]
      public IActionResult AddService(int id, int addedServiceId)
      {
          Stylist selectedStylist = Stylist.FindStylist(id);
          Service selectedService = Service.FindService(addedServiceId);
          selectedStylist.AddService(selectedService);
          return RedirectToAction("StylistInfo");
      }

      [HttpGet("/stylists/{id}/edit")]
      public IActionResult EditStylist(int id)
      {
          Stylist selectedStylist = Stylist.FindStylist(id);
          return View(selectedStylist);
      }

      [HttpPost("/stylists/{id}/edit")]
      public IActionResult EditThisStylist(int id, string newName)
      {
          Stylist selectedStylist = Stylist.FindStylist(id);
          selectedStylist.EditStylist(newName);
          return RedirectToAction("StylistInfo");
      }

      [HttpGet("/stylists/{id}/delete")]
      public IActionResult DeleteThisStylist()
      {
          return RedirectToAction("ViewAllStylists");
      }

      [HttpPost("/stylists/{id}/delete")]
      public IActionResult DeleteStylist(int id)
      {
          Stylist selectedStylist = Stylist.FindStylist(id);
          selectedStylist.DeleteStylist();
          return RedirectToAction("ViewAllStylists");
      }
    }
}
