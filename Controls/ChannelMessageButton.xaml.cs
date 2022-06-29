using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace KTU_Social.Controls
{
    public sealed partial class ChannelMessageButton : Button, INotifyPropertyChanged
    {
        public ChannelMessageButton()
        {
            InitializeComponent();
        }

        private ImageSource _profilePicture;
        public ImageSource ProfilePicture { get { return _profilePicture; } set { _profilePicture = value; OnPropertyChanged(nameof(ProfilePicture)); } }

        private string _accountName;
        public string AccountName { get { return _accountName; } set { _accountName = value; OnPropertyChanged(nameof(AccountName)); } }

        private string _datetime;
        public string Datetime { get { return _datetime; } set { _datetime = value; OnPropertyChanged(nameof(Datetime)); } }

        private string _message;
        public string Message { get { return _message; } set { _message = value; OnPropertyChanged(nameof(Message)); } }

        private int _verified;
        public int Verified { get { return _verified; } set { _verified = value; OnPropertyChanged(nameof(Verified)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            if (Verified > 0)
                VerifiedIcon.Visibility = Visibility.Visible;
        }
    }
}
