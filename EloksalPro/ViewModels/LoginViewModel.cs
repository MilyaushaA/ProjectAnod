using EloksalPro.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EloksalPro.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _rememberMe;
        private UserRepository userRepo=new UserRepository();
        public bool RememberMe
        {
            get { return _rememberMe; }
            set
            {
                _rememberMe = value;
                OnPropertyChanged(nameof(RememberMe));
            }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }
        public SecureString Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }
        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            ReadFileLogin();
        }
        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
        private void ExecuteLoginCommand(object obj)
        {
            if (RememberMe)
            {
                SaveFileLogin();
            }
           
            var isValidUser = userRepo.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* Invalid username or password";
            }
        }
        private void SaveFileLogin()
        {
            string filePath = @"C:\Password\password.txt";
            // Создание объекта StreamWriter для записи данных в файл
            try
            {
                if (!File.Exists(filePath))
                {
                    string Password = @"C:\Password";
                    DirectoryInfo drInfo = new DirectoryInfo(Password);
                    drInfo.Create();
                    // Если файл не существует, создать его и записать данные
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.Write(Username);
                    }
                }
                else if (File.Exists(filePath))
                {
                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                        writer.Write(Username);
                    }
                }
            }
           
           catch
            {
                MessageBox.Show("Создайте на диске C: -> Новая папка 'Password', для сохранения Логина");
            }

        }
        private void ReadFileLogin()
        {
            string filePath = @"C:\Password\password.txt";
            try
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.Default))
                {
                    Username = reader.ReadLine();
                }
            }
            catch
            {
                Username = "";
            }
        }
    }
}
