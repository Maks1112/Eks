using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Serializable]
    public class Chat:BaseModel
    {
        public string Name { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public List<Message> Messages { get; set; }
    }
}
