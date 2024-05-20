using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging; 
using System.Collections.Generic; 

namespace Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Constructor injection of ILogger
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IndexModel(ILogger<IndexModel> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _logger = logger;
        }

        // Properties
        public string CarRentalStoreName { get; set; }
        public List<Car> AvailableCars { get; set; }

        // OnGet method to handle GET requests
        public void OnGet()
        {
            CarRentalStoreName = "Div Patel Car Rentals";
            AvailableCars = new List<Car>
            {
                new Car { Model = "Toyota Camry", Brand = "Toyota", ImageUrl = "/Images/toyota camry.png", Description = "A reliable family sedan with spacious interior." },
                new Car { Model = "Honda Civic", Brand = "Honda", ImageUrl = "/Images/Honda Civic.jpg",Description = "A fuel-efficient compact car known for its sporty design." },
                new Car { Model = "Ford Mustang", Brand = "Ford", ImageUrl = "/Images/Ford Mustang.jpg",Description = "A legendary American muscle car with powerful performance." }
            };
        }

        // Car class representing car details
        public class Car
        {
            // Properties
            public required string Model { get; set; }
            public  required string Brand { get; set; }
            public required string Description { get; set; }
            public int ReservedCount { get; set; }
            public  string? ImageUrl { get; internal set; }
        }
    }
}
