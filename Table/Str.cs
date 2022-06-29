using System.ComponentModel;

namespace KTU_Social.Table
{
    public class Str : INotifyPropertyChanged
    {
        private string _tag;
        public string Tag { get { return _tag; } set { _tag = value; OnPropertyChanged(nameof(Tag)); } }

        private string _en;
        public string En { get { return _en; } set { _en = value; OnPropertyChanged(nameof(En)); } }

        private string _tr;
        public string Tr { get { return _tr; } set { _tr = value; OnPropertyChanged(nameof(Tr)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}