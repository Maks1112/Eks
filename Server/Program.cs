using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using Models.Entities;
using Models;
using System.Runtime.Serialization.Formatters.Binary;
using Server.Repositories.Implementation;

using Server.Data;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            Start();
            Console.ReadKey();
        }


        static void Start()
        {
            UserRepository userRepository = new UserRepository();
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001);
            TcpListener listener = new TcpListener(endPoint);
            listener.Start(10);

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                var netStream = client.GetStream();




                switch ((RequestType)binaryFormatter.Deserialize(netStream))
                {
                    case RequestType.LoggedIn:

                        string email = (string)binaryFormatter.Deserialize(netStream);
                        string password = (string)binaryFormatter.Deserialize(netStream);

                        Console.WriteLine($"Запрос на попытку входа: {email} {password}");


                        var user = userRepository.GetUser(email, password);
                        if (user != null)
                        {
                            Console.WriteLine("Отправка статуса Ок");
                            binaryFormatter.Serialize(netStream, RequestStatus.Ok);

                            Console.WriteLine("Отправка статуса объекта ");
                            binaryFormatter.Serialize(netStream, user);

                        }
                        else
                        {
                            Console.WriteLine("Отправка статуса Error");
                            binaryFormatter.Serialize(netStream, RequestStatus.Error);
                        }

                        break;

                    case RequestType.Registration:

                        var newUser = (User)binaryFormatter.Deserialize(netStream);
                        var status = (userRepository.GetUser(newUser.Email, newUser.Password) == null) ? RequestStatus.Ok : RequestStatus.Error;

                        if(status == RequestStatus.Ok)
                        {
                            userRepository.Create(newUser);
                            userRepository.Save();
                        }


                        binaryFormatter.Serialize(netStream, status);
                        break;

                    default:
                        break;
                }

                client.Close();
            }
        }


        static void testData()
        {
            DataManagerMCC dm = new DataManagerMCC();

            User user = new User()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "Email",
                Password = "Password"
            };


            dm.Users.Add(user);
            dm.SaveChanges();

        }
    }
}
