using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace KTU_Social.Controls
{
    public sealed partial class PersonButton : Button
    {
        public PersonButton()
        {
            InitializeComponent();
        }

        private ImageSource _icon = (SvgImageSource)Application.Current.Resources["User"];
        public ImageSource Icon { get { return _icon; } set { _icon = value; OnPropertyChanged(nameof(Icon)); } }

        private string _personName;
        public string PersonName { get { return _personName; } set { _personName = value; OnPropertyChanged(nameof(PersonName)); } }

        private Visibility _verified = Visibility.Collapsed;
        public Visibility Verified { get { return _verified; } set { _verified = value; OnPropertyChanged(nameof(Verified)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}