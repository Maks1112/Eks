using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Net.Sockets;

using Models.Entities;
using Models;

namespace MCC.Services
{
    class ClientService
    {

        BinaryFormatter binaryFormatter;
        IPEndPoint endPoint;

        public ClientService()
        {
            endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001);
            binaryFormatter = new BinaryFormatter();

        }



        public User GetUser(string email, string password)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            var netStream = tcpClient.GetStream();

            binaryFormatter.Serialize(netStream, RequestType.LoggedIn);
            binaryFormatter.Serialize(netStream, email);
            binaryFormatter.Serialize(netStream, password);


            if((RequestStatus)binaryFormatter.Deserialize(netStream) == RequestStatus.Ok)
            {
                var user = (User)binaryFormatter.Deserialize(netStream);
                tcpClient.Close();
                return user;
            }

            tcpClient.Close();
            return null;
        }

        public bool UserRegistration(User newUser)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(endPoint);
            var netStream = tcpClient.GetStream();

            binaryFormatter.Serialize(netStream, RequestType.Registration);
            binaryFormatter.Serialize(netStream, newUser);

            var status = (RequestStatus)binaryFormatter.Deserialize(netStream);
            tcpClient.Close();

            if (status == RequestStatus.Ok)
                return true;
            else
                return false;

        }



    }
}
