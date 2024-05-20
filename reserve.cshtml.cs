using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project.Pages
{
    public class ReserveModel : PageModel
    {
        public string? SelectedCar { get; set; }
        public string? UserName { get; set; }
        public string? ContactInfo { get; set; }
        public DateTime ReservationDateTime { get; set; }

        public List<Car> AvailableCars { get; } = new List<Car>
        {
            new Car { Model = "Toyota Camry", Brand = "Toyota", ImageUrl = "/Images/toyota camry.png", Description = "A reliable family sedan with spacious interior." },
            new Car { Model = "Honda Civic", Brand = "Honda", ImageUrl = "/Images/Honda Civic.jpg", Description = "A fuel-efficient compact car known for its sporty design." },
            new Car { Model = "Ford Mustang", Brand = "Ford", ImageUrl = "/Images/Ford Mustang.jpg", Description = "A legendary American muscle car with powerful performance." }
        };

        public IActionResult OnPost(string selectedCar, string userName, string contactInfo, DateTime reservationDateTime)
        {
            SelectedCar = selectedCar;
            UserName = userName;
            ContactInfo = contactInfo;
            ReservationDateTime = reservationDateTime;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save reservation
            SaveReservation(new ReservationData
            {
                CarModel = SelectedCar,
                DateTime = ReservationDateTime,
                UserInfo = $"{UserName} - {ContactInfo}"
            });

            // Handle reservation logic here
            return RedirectToPage("/Confirmation", new { car = SelectedCar, user = UserName });
        }

        private void SaveReservation(ReservationData reservation)
        {
            // Read existing reservations from JSON file
            string jsonFilePath = "Reservations.json";
            string jsonData = System.IO.File.ReadAllText(jsonFilePath);
            var reservations = JsonConvert.DeserializeObject<List<ReservationData>>(jsonData) ?? new List<ReservationData>();

            // Add the new reservation
            reservations.Add(reservation);

            // Serialize the updated list back to JSON
            jsonData = JsonConvert.SerializeObject(reservations, Formatting.Indented);

            // Write the updated JSON back to the file
            System.IO.File.WriteAllText(jsonFilePath, jsonData);
        }
    }

    public class Car
    {
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }

    public class ReservationData
    {
        public string? CarModel { get; set; }
        public DateTime DateTime { get; set; }
        public string? UserInfo { get; set; }
    }
}
