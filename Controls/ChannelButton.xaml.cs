using KTU_Social.View;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KTU_Social.Controls
{
    public sealed partial class ChannelButton : Button, INotifyPropertyChanged
    {
        public ChannelButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChannelView channelView = new ChannelView();
            channelView.Name = Name;
            channelView.VM.Model.Code = _channelCode;
            channelView.VM.Model.Title = Functions.GetString(_channelCode);
            Grid middlePanel = (Grid)App.login.home.FindName("MiddlePanel");
            middlePanel.Children.Add(channelView);
        }

        private string _channelName;
        public string ChannelName { get { return _channelName; } set { _channelName = value; OnPropertyChanged(nameof(ChannelName)); } }

        private string _channelCode;
        public string ChannelCode { get { return _channelCode; } set { _channelCode = value; OnPropertyChanged(nameof(ChannelCode)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}