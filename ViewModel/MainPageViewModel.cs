using System.ComponentModel;

namespace KTU_Social.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(Title)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
