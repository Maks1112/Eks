using MCC.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.Entities;

namespace MCC.MVVM.ViewModels
{
    class MainViewModel:BaseViewModel
    {
        private UserProfileViewModel userProfileVM;
        private ServerViewModel serverVM;


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


        private BaseViewModel _currentContent;
        public BaseViewModel CurrentContent
        {
            get => _currentContent;
            set
            {
                _currentContent = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            userProfileVM = new UserProfileViewModel();
            serverVM = new ServerViewModel();

            userProfileVM.CurrentUser = new User()
            {
                FirstName = "First",    
                LastName = "Last",
                ProfileStatus = "Status"
            };


            CurrentContent = userProfileVM;

        }

        #region Commands

        private RelayCommand _userProfileCommand;
        public RelayCommand UserProfileCommand
        {
            get => _userProfileCommand ?? (_userProfileCommand = new RelayCommand(obj =>
            {
                CurrentContent = userProfileVM;
            }));
        }


        private RelayCommand _serverCommand;
        public RelayCommand ServerCommand
        {
            get => _serverCommand ?? (_serverCommand = new RelayCommand(obj =>
            {
                CurrentContent = serverVM;
            }));
        }
        #endregion
    }
}
