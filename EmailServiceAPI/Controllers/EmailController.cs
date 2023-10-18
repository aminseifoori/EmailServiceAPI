using EmailService.Interface;
using EmailService.Model;
using EmailService.Service;
using EmailServiceAPI.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace EmailServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender emailSender;

        public EmailController(IEmailSender _emailSender)
        {
            emailSender = _emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm] MessageDto messageDto)
        {
                Message message = new Message(messageDto.To, messageDto.Subject, messageDto.Content, messageDto.Attachment);
                await emailSender.SendEmailAsync(message);
                return Ok();
        }

        [HttpGet]
        public IActionResult SendEmailGet()
        {
            List<EmailAddress> address = new List<EmailAddress>();
            address.Add(new EmailAddress { Address = "amin.seifoori@gmail.com", DisplayName = "Amin" });
            var message = new Message(address, "Test email", "This is the content from our email.");
            emailSender.SendEmail(message);
            return Ok();
        }

    }
}


