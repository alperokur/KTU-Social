using KTU_Social.ViewModel;
using Windows.UI.Xaml.Controls;

namespace KTU_Social.View
{
    public sealed partial class ControlPanelView : UserControl
    {
        public ControlPanelView()
        {
            InitializeComponent();
            DataContext = VM;
        }

        public ControlPanelViewModel VM = new ControlPanelViewModel();
    }
}
