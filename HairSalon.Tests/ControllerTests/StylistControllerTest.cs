using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistControllerTest
    {
      [TestMethod]
          public void ViewAllStylists_ReturnsCorrectView_True()
          {
              StylistController controller = new StylistController();
              IActionResult indexView = controller.ViewAllStylists();
              Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          }

      [TestMethod]
          public void ViewAllStylists_HasCorrectModelType_StylistList()
          {
              StylistController controller = new StylistController();
              IActionResult actionResult = controller.ViewAllStylists();
              ViewResult indexView = controller.ViewAllStylists() as ViewResult;
              var result = indexView.ViewData.Model;
              Assert.IsInstanceOfType(result, typeof(List<Stylist>));
          }

          
    }
}
