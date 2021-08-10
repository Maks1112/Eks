using MCC.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using MCC.Services;



namespace MCC.MVVM.ViewModels
{
    class SignInViewModel:BaseViewModel
    {
        private ClientService clientService = new ClientService();


        public string Email { get; set; }
        public string Password { get; set; }



        private RelayCommand _signInCommand;
        public RelayCommand SignInCommand
        {
            get => _signInCommand ?? (_signInCommand = new RelayCommand(obj =>
            {


                var currentUser = clientService.GetUser(Email, Password);

                if(currentUser != null)
                {
                    //MessageBox.Show(currentUser.FirstName + "  " + currentUser.LastName);

                    MainWindow mainWindow = new MainWindow();
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }));

        }

    }
}
