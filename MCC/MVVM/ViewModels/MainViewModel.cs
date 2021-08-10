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
        public User CurrentUser { get; set; }



        private UserProfileViewModel userProfileVM;
        private ServerViewModel serverVM;



        private object _currentContent;
        public object CurrentContent
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
            CurrentContent = userProfileVM;
        }


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
    }
}
