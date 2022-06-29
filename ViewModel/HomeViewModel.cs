using KTU_Social.Model;
using System.ComponentModel;

namespace KTU_Social.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private Home _model = new Home();
        public Home Model { get { return _model; } set { _model = value; OnPropertyChanged(nameof(Model)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
