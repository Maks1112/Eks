using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Serializable]
    public class Message:BaseModel
    {
        // Sender
        public int UserId { get; set; }
        public User User { get; set; }

        public string Content { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }

        public DateTime Time { get; set; }

    }
}
