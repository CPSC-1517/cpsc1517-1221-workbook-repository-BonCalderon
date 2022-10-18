using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        [BindProperty]
        public string FeedBackMessage { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string Recipient { get; set; }

        [BindProperty]
        public string MailSubject { get; set; }

        [BindProperty]
        public string MailMessage { get; set; }


        public void OnGet()
        {

            //var sendMailClient = new SmtpClient();
            //sendMailClient.Host = "smtp@gmail.com";
            //sendMailClient.Port = 587;
            //sendMailClient.EnableSsl = true;
            //var sendMailCredentials = new NetworkCredential();
            //sendMailCredentials.UserName = Username;
            //sendMailCredentials.Password = Password;
            //sendMailClient.Credentials = sendMailCredentials;

            //var mailMessage = new MailMessage(Username, Recipient);
            //mailMessage.Subject = MailSubject;
            //mailMessage.Body = MailMessage;
            //sendMailClient.Send(mailMessage);
        }
        public void OnPost()
        {

        }
    }
}
