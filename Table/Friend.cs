using System.ComponentModel;

namespace KTU_Social.Table
{
    public class Friend : INotifyPropertyChanged
    {
        private int _account_id;
        public int Account_id { get { return _account_id; } set { _account_id = value; OnPropertyChanged(nameof(Account_id)); } }

        private int _friend_id;
        public int Friend_id { get { return _friend_id; } set { _friend_id = value; OnPropertyChanged(nameof(Friend_id)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}