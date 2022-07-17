using EmailServiceAPI.Interface;
using EmailServiceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmailServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        // GET: api/<EmailController>
        [HttpPost("SendEmail")]
        public IEnumerable<string> SendEmail([FromForm]MessageDTO message)
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            if (message.Attachments == null)
            {
                message.Attachments = files;
            }
            var msg = new Message(message.To, message.Subject, message.Content, message.Attachments);
            _emailSender.SendEmail(msg);
            return new string[] { "Sucess", "200" };
        }

        [HttpPost("SendEmailAsync")]
        public async Task<IEnumerable<string>> SendEmailAsync([FromForm] MessageDTO message)
        {
            var files = Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
            if (message.Attachments == null)
            {
                message.Attachments = files;
            }
            var msg = new Message(message.To, message.Subject, message.Content, message.Attachments);
            await _emailSender.SendEmailAsync(msg);
            return new string[] { "Sucess", "200" };
        }

        


    }
}
