using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailServiceAPI.Models
{
    public class MessageDTO
    {
        public IEnumerable<string> To { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }
        public IFormFileCollection Attachments { get; set; }


        //private IFormCollection file(IFormCollection attachment)
        //{
        //    return Request.Form.Files.Any() ? Request.Form.Files : new FormFileCollection();
        //}

    }
}
