using KTU_Social.Model;
using System.ComponentModel;

namespace KTU_Social.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private Login _model = new Login();
        public Login Model { get { return _model; } set { _model = value; OnPropertyChanged(nameof(Model)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
