using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Stylist> stylistList = Stylist.GetAllStylists();
            return View(stylistList);
        }

        [HttpPost("/clients")]
        public ActionResult CreateClient()
        {
            string clientName = Request.Form["client-name"];
            int clientStylistId = int.Parse(Request.Form["stylist-assign-select"]);
            Client newClient = new Client(clientName, clientStylistId);
            newClient.SaveClient();
            List<Stylist> stylistList = Stylist.GetAllStylists();
            return View("Index", stylistList);

        }

        [HttpPost("/select-client")]
        public ActionResult SelectClient()
        {
            int stylistId = int.Parse(Request.Form["stylist-info-select"]);
            Stylist selectedStylist = Stylist.FindStylist(stylistId);
            List<Client> selectedClientList = selectedStylist.GetClientList();
            return View(selectedClientList);

        }

        // [HttpPost("/client-info")]
        // public ActionResult ClientInfo()
        // {
        //
        // }
    }
}
