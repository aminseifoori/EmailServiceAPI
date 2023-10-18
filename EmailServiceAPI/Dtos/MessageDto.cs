using EmailService.Model;


namespace EmailServiceAPI.Dtos
{
    public class MessageDto
    {
        public List<EmailAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
