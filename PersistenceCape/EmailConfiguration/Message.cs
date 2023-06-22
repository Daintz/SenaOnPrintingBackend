using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceCape.EmailConfiguration
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        public String Subject { get; set; }

        public String Body { get; set; }

        public Message(IEnumerable<String> to, string subject, string body) {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress("email", x)));
            Subject = subject;
            Body = body;
        }
    }
}
