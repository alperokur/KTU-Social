using System.ComponentModel;

namespace KTU_Social.Model
{
    public class Login : INotifyPropertyChanged
    {
        private string _welcome;
        public string Welcome 
        { 
            get { return _welcome; } 
            set { 
                _welcome = value;
                OnPropertyChanged(nameof(Welcome)); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }

        private string _info;
        public string Info { get { return _info; } set { _info = value; OnPropertyChanged(nameof(Info)); } }

        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(Username)); } }

        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }

        private string _rememberMe;
        public string RememberMe { get { return _rememberMe; } set { _rememberMe = value; OnPropertyChanged(nameof(RememberMe)); } }

        private string _loginText;
        public string LoginText { get { return _loginText; } set { _loginText = value; OnPropertyChanged(nameof(LoginText)); } }

        
    }
}