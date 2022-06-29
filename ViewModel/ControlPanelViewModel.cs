using KTU_Social.Model;
using KTU_Social.Table;
using System.ComponentModel;

namespace KTU_Social.ViewModel
{
    public class ControlPanelViewModel : INotifyPropertyChanged
    {
        private Channel _model = new Channel();
        public Channel Model
        { 
            get { return _model; } 
            set { 
                _model = value; 
                OnPropertyChanged(nameof(Model)); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
        { 
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}
