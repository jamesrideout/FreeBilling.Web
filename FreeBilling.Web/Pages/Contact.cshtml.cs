using FreeBilling.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreeBilling.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IEmailService _emailservice;

        public ContactModel(IEmailService emailservice)
        {
            _emailservice = emailservice;
        }

        public string Title { get; set; } = "Contact Me";
        public string Message { get; set; } = "";
        [BindProperty]
        public ContactViewModel Contact { get; set; } = new ContactViewModel()
        {
            Name = "James Rideout"
        };
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                _emailservice.SendMail("james_rideout@hotmail.co.uk", Contact.Email, Contact.Subject, Contact.Body);
                Contact = new ContactViewModel();
                ModelState.Clear();
                Message = "Sent...";
            }
            else
            {
                Message = "Please fix errors";
            }
        }
    }
}
