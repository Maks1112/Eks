using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public enum RequestStatus
    {
        Ok,
        Error
    }


    [Serializable]
    public enum RequestType
    {
        LoggedIn,
        Registration

    }




}
