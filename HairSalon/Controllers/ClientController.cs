using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/clients")]
        public IActionResult ViewAllClients()
        {
            List<Client> clientList = Client.GetAllClients();
            return View(clientList);
        }

        [HttpGet("/clients/new")]
        public IActionResult CreateClientForm()
        {
            return View();

        }

        [HttpPost("/clients/new")]
        public IActionResult CreateClient(string clientName)
        {
            Client newClient = new Client(clientName);
            newClient.SaveClient();
            return RedirectToAction("ViewAllClients");
        }

        [HttpGet("/clients/{id}")]
        public IActionResult ClientInfo(int id)
        {
            Client selectedClient = Client.FindClient(id);
            return View(selectedClient);
        }

        [HttpPost("/clients/{id}")]
        public IActionResult AddStylist(int id, int addedStylistId)
        {
            Client selectedClient = Client.FindClient(id);
            Stylist selectedStylist = Stylist.FindStylist(addedStylistId);
            selectedClient.AddStylist(selectedStylist);
            return RedirectToAction("ClientInfo");
        }


    }
}
