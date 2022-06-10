using Spire.Email;
using Spire.Email.Smtp;
using Spire.Email.IMap;
using RestAPI_XF1Online.Models;
using HtmlAgilityPack;

namespace RestAPI_XF1Online.Email
{
    public static class EmailService
    {
        public static void SendConfirmationEmail(Player player){

            MailAddress addressFrom = "SonderTechServices@gmail.com";
	        MailAddress addressTo = player.Email;

            MailMessage message = new MailMessage(addressFrom, addressTo);

            var hyperlink = "https://localhost:7133/players/auth/" + player.Username;

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.Load(@"Email/emailFormat.html");
            var linkAtt = htmlDocument.DocumentNode.SelectSingleNode("//a[@href]").Attributes["href"].Value = hyperlink;

            message.Subject = "[XF1-Online] Confirm Email Address for your account: " + player.Username;
            message.BodyHtml = htmlDocument.DocumentNode.OuterHtml;         

	        message.Date = DateTime.Now;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.ConnectionProtocols = ConnectionProtocols.Ssl;
            smtp.Username = addressFrom.Address;
            smtp.Password = "cojldtpapyncdwcr";
            smtp.Port = 587;

            smtp.SendOne(message);
        }
    }
}
