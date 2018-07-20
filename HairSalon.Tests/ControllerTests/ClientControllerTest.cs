using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {
      [TestMethod]
          public void ViewAllClients_ReturnsCorrectView_True()
          {
              ClientController controller = new ClientController();
              IActionResult indexView = controller.ViewAllClients();
              Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          }

      [TestMethod]
          public void ViewAllClients_HasCorrectModelType_ClientList()
          {
              ClientController controller = new ClientController();
              IActionResult actionResult = controller.ViewAllClients();
              ViewResult indexView = controller.ViewAllClients() as ViewResult;
              var result = indexView.ViewData.Model;
              Assert.IsInstanceOfType(result, typeof(List<Client>));
          }

    }
}
