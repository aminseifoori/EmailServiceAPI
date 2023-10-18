using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Model
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public IFormFile? Attachment { get; set; }
        public Message(IEnumerable<EmailAddress> to, string subject, string content, IFormFile attachment = null)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x.DisplayName, x.Address)));
            Subject = subject;
            Content = content;
            Attachment = attachment;
        }
    }
}
