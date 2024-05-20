using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project.Pages
{
    public class ConfirmationModel : PageModel
    {
        public  required string Car { get; set; }

        public new required string User { get; set; }


        public void OnGet(string car, string user)
        {
            Car = car;
            User = user;
        }
    }
}
