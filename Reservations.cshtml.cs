using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Project.Pages
{
    public class ReservationsModel : PageModel
    {
        public required List<Reservation> ReservationList { get; set; }

        public void OnGet()
        {
            string jsonFilePath = "Reservations.json";
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
#pragma warning disable CS8601 // Possible null reference assignment.
            ReservationList = JsonConvert.DeserializeObject<List<Reservation>>(jsonData);
#pragma warning restore CS8601 // Possible null reference assignment.
        }
    }

    public class Reservation
    {
        public required string CarModel { get; set; }
        public required string DateTime { get; set; }
        public required string UserInfo { get; set; }
    }
}
