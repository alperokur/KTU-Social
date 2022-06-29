using System.ComponentModel;

namespace KTU_Social.Table
{
    public class Category : INotifyPropertyChanged
    {
        private string _code;
        public string Code { get { return _code; } set { _code = value; OnPropertyChanged(nameof(Code)); } }

        private int _priority;
        public int Priority { get { return _priority; } set { _priority = value; OnPropertyChanged(nameof(Priority)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}