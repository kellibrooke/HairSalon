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

      [HttpGet("/services/new")]
      public IActionResult CreateServiceForm()
      {
          return View();

      }

      [HttpPost("/services/new")]
      public IActionResult CreateService(string serviceName)
      {
          Service newService = new Service(serviceName);
          newService.SaveService();
          return RedirectToAction("ViewAllServices");
      }

      [HttpGet("/services/{id}")]
      public IActionResult ServiceInfo(int id)
      {
          Service selectedService = Service.FindService(id);
          return View(selectedService);
      }

      [HttpPost("/services/{id}")]
      public IActionResult AddStylist(int id, int addedStylistId)
      {
          Service selectedService = Service.FindService(id);
          Stylist selectedStylist = Stylist.FindStylist(addedStylistId);
          selectedService.AddStylist(selectedStylist);
          return RedirectToAction("ServiceInfo");
      }
    }
}
