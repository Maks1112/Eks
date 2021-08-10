using MCC.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCC.Services;
using Models.Entities;
using System.Windows;

namespace MCC.MVVM.ViewModels
{
    class SignUpViewModel:BaseViewModel
    {
        ClientService clientService = new ClientService();

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }


        private RelayCommand _signUpCommand;
        public RelayCommand SignUpCommand
        {
            get => _signUpCommand ?? (_signUpCommand = new RelayCommand(obj =>
            {
                User newUser = new User();
                newUser.FirstName = FirstName;
                newUser.LastName = LastName;
                newUser.Email = Email;
                newUser.Password = Password;

                if(clientService.UserRegistration(newUser))
                {
                    MessageBox.Show("Ok");
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }));

        }


    }
}
