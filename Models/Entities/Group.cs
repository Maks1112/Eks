using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Serializable]
    public class Group:BaseModel
    {
        public string Name { get; set; }

        public int ServerId { get; set; }
        public Server Server { get; set; }

        public List<Chat> Chats { get; set; }
    }
}
