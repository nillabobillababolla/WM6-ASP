using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rabbit.Models.Entities
{
    [Table("MailLogs")]
    public class MailLog
    {
        public MailLog()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
