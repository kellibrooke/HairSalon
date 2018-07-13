using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost("/clients")]
        public ActionResult ClientHome()
        {
          string clientName = Request.Form["client-name"];
          int clientStylistId = int.Parse(Request.Form["stylist-select"]);
          Client newClient = new Client(clientName, clientStylistId);
          newClient.SaveClient();
        }
        [HttpPost("/client-info")]
        public ActionResult ClientInfo()
        {

        }
    }
}
