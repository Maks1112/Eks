using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.Entities;

namespace MCC.MVVM.ViewModels
{
    class UserProfileViewModel:BaseViewModel
    {
        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }


        public UserProfileViewModel()
        {
            Console.WriteLine("1");
        }



    }
}
