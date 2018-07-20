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

          // [TestMethod]
          //     public void CreateStylist_ReturnsCorrectView_True()
          //     {
          //         StylistController controller = new StylistController();
          //         ActionResult indexView = controller.CreateStylist();
          //         Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          //     }
          //
          // [TestMethod]
          //     public void CreateStylist_HasCorrectModelType_StylistList()
          //     {
          //         StylistController controller = new StylistController();
          //         IActionResult actionResult = controller.CreateStylist();
          //         ViewResult indexView = controller.CreateStylist() as ViewResult;
          //         var result = indexView.ViewData.Model;
          //         Assert.IsInstanceOfType(result, typeof(List<Stylist>));
          //     }

          // [TestMethod]
          //     public void StylistInfo_ReturnsCorrectView_True()
          //     {
          //         StylistController controller = new StylistController();
          //         ActionResult indexView = controller.StylistInfo();
          //         Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          //     }
          //
          // [TestMethod]
          //     public void StylistInfo_HasCorrectModelType_StylistList()
          //     {
          //         StylistController controller = new StylistController();
          //         IActionResult actionResult = controller.StylistInfo();
          //         ViewResult indexView = controller.StylistInfo() as ViewResult;
          //         var result = indexView.ViewData.Model;
          //         Assert.IsInstanceOfType(result, typeof(Stylist));
          //     }
    }
}
