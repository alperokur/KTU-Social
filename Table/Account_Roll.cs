using System.ComponentModel;

namespace KTU_Social.Table
{
    public class Account_Roll : INotifyPropertyChanged
    {
        private int _account_id;
        public int Account_id { get { return _account_id; } set { _account_id = value; OnPropertyChanged(nameof(Account_id)); } }

        private string _roll;
        public string Roll { get { return _roll; } set { _roll = value; OnPropertyChanged(nameof(Roll)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}