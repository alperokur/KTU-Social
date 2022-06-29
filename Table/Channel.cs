using System.ComponentModel;

namespace KTU_Social.Table
{
    public class Channel : INotifyPropertyChanged
    {
        private string _title;
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(Title)); } }

        private string _code;
        public string Code { get { return _code; } set { _code = value; OnPropertyChanged(nameof(Code)); } }

        private string _category;
        public string Category { get { return _category; } set { _category = value; OnPropertyChanged(nameof(Category)); } }

        private int _period;
        public int Period { get { return _period; } set { _period = value; OnPropertyChanged(nameof(Period)); } }

        private int _degree;
        public int Degree { get { return _degree; } set { _degree = value; OnPropertyChanged(nameof(Degree)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}