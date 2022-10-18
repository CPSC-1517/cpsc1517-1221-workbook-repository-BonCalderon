using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;

namespace WestwindWebApp.Pages
{
    public class SendMailModel : PageModel
    {
        public void OnGet() 
        {
            //introduction instruction on dependancy injection
            //var gmailUsername = Configuration["GmailCredentials:Username"];  
            //var gmailAppPassword = Configuration["GmailCredentials:Password"];
            //FeedBackMessage = $"Gmail username = {gmailUsername} <br />";
            //FeedBackMessage += $"Gmail app password = {gmailAppPassword} <br />";
        }

        private readonly IConfiguration Configuration;
        public SendMailModel(IConfiguration configuration) //constructor dependency injection getting the configuration for the setting (configuration)
        {
            this.Configuration = configuration;  //relates to json file appsetting
        }

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

        //page handler methods
        public void OnPostSendMail()
        {
            //FeedBackMessage = "<h2>Send Mail button clicked</h2>";

            var sendMailClient = new SmtpClient(); //smtp protocol that allows you to send email
            sendMailClient.Host = "smtp.gmail.com"; //to send email specify which server to send it
            sendMailClient.Port = 587; //need to set what port to yuse
            sendMailClient.EnableSsl = true; 
            var sendMailCredentials = new NetworkCredential(); // identity of the user by specifying their user name and password
            Username = Configuration["GmailCredentials:Username"];
            Password = Configuration["GmailCredentials:Password"];
            sendMailCredentials.UserName = Username;
            sendMailCredentials.Password = Password;
            sendMailClient.Credentials = sendMailCredentials;

            var sendFromAddress = new MailAddress(Username);
            var sendToAddress = new MailAddress(Recipient);

            var mailMessage = new MailMessage(sendFromAddress, sendToAddress);
            mailMessage.Subject = MailSubject;
            mailMessage.Body = MailMessage;

            try
            {
                sendMailClient.Send(mailMessage);
                FeedBackMessage = "<div class='alert alert-primary'>Email Sent!</div>";
            }
            catch (Exception ex)
            {
                FeedBackMessage = $"<div class='alert alert-danger'>Error sending email {ex}!</div>";

            }
            
        }

        public void OnPostClearForm()
        {
            FeedBackMessage = "<h2>Clear Form button clicked</h2>";
        }

        public void OnPost()
        {

        }
    }
}
