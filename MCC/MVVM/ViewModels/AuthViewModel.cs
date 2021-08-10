using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MCC.Commands;
using MCC.Utilities;
//using System.Security.Cryptography;

namespace MCC.MVVM.ViewModels
{
    class AuthViewModel : BaseViewModel
    {

        private SignInViewModel signInVM;
        private SignUpViewModel signUpVM;



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


        public AuthViewModel()
        {
            signInVM = new SignInViewModel();
            signUpVM = new SignUpViewModel();
            CurrentContent = signInVM;
        }


        private RelayCommand _signInCommand;
        public RelayCommand SignInCommand
        {
            get => _signInCommand ?? (_signInCommand = new RelayCommand(obj =>
            {
                CurrentContent = signInVM;
            }));
        }


        private RelayCommand _signUpCommand;
        public RelayCommand SignUpCommand
        {
            get => _signUpCommand ?? (_signUpCommand = new RelayCommand(obj =>
            {
                CurrentContent = signUpVM;
            }));
        }

    }
}
