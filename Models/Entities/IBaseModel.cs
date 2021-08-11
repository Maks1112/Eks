using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
   
    public interface IBaseModel
    {
        int Id { get; set; }
    }

    [Serializable]
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }
    }
}
