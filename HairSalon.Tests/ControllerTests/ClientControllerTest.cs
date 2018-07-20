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

          // [TestMethod]
          //     public void CreateClient_ReturnsCorrectView_True()
          //     {
          //         ClientController controller = new ClientController();
          //         ActionResult indexView = controller.CreateClient();
          //         Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          //     }
          //
          // // [TestMethod]
          // //     public void CreateClient_HasCorrectModelType_StylistList()
          // //     {
          // //         ClientController controller = new ClientController();
          // //         IActionResult actionResult = controller.CreateClient();
          // //         ViewResult indexView = controller.CreateClient() as ViewResult;
          // //         var result = indexView.ViewData.Model;
          // //         Assert.IsInstanceOfType(result, typeof(List<Stylist>));
          // //     }

          // [TestMethod]
          //     public void SelectClient_ReturnsCorrectView_True()
          //     {
          //         ClientController controller = new ClientController();
          //         ActionResult indexView = controller.SelectClient();
          //         Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          //     }

          // [TestMethod]
          //     public void SelectClient_HasCorrectModelType_ClientList()
          //     {
          //         ClientController controller = new ClientController();
          //         IActionResult actionResult = controller.SelectClient();
          //         ViewResult indexView = controller.SelectClient() as ViewResult;
          //         var result = indexView.ViewData.Model;
          //         Assert.IsInstanceOfType(result, typeof(List<Client>));
          //     }
          //
          // [TestMethod]
          //     public void ClientInfo_ReturnsCorrectView_True()
          //     {
          //         ClientController controller = new ClientController();
          //         ActionResult indexView = controller.ClientInfo();
          //         Assert.IsInstanceOfType(indexView, typeof(ViewResult));
          //     }
          //
          // [TestMethod]
          //     public void ClientInfo_HasCorrectModelType_Client()
          //     {
          //         ClientController controller = new ClientController();
          //         IActionResult actionResult = controller.ClientInfo();
          //         ViewResult indexView = controller.ClientInfo() as ViewResult;
          //         var result = indexView.ViewData.Model;
          //         Assert.IsInstanceOfType(result, typeof(Client));
          //     }
    }
}
