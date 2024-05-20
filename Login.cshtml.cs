using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

    public class LoginModel : PageModel
    {
        public IActionResult OnPost(string username, string password)
        {
            // Load user credentials from JSON file
            var userCredentials = LoadUserCredentials("credentials.json");

            // Validate provided credentials
            if (ValidateCredentials(userCredentials, username, password))
            {
                // Redirect to desired page after successful login
                return RedirectToPage("/Index");
            }
            else
            {
                // Redirect to error page for incorrect login
                return RedirectToPage("/Error");
            }
        }

        private List<UserCredentials> LoadUserCredentials(string filePath)
        {
            // Load user credentials from JSON file
            string jsonData = System.IO.File.ReadAllText(filePath);
#pragma warning disable CS8603 // Possible null reference return.
        return JsonConvert.DeserializeObject<List<UserCredentials>>(jsonData);
#pragma warning restore CS8603 // Possible null reference return.
    }

        private bool ValidateCredentials(List<UserCredentials> userCredentials, string username, string password)
        {
            // Validate provided username and password against loaded user credentials
            foreach (var user in userCredentials)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true; // Credentials are valid
                }
            }
            return false; // Credentials are invalid
        }
    }

    public class UserCredentials
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

