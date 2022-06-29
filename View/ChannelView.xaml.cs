using KTU_Social.Controls;
using KTU_Social.Table;
using KTU_Social.ViewModel;
using System;
using System.Threading.Tasks;
using System.Timers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KTU_Social.View
{
    public sealed partial class ChannelView : UserControl
    {
        public ChannelView()
        {
            InitializeComponent();
            DataContext = VM;
        }

        public ChannelViewModel VM = new ChannelViewModel();

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (TextArea.Text != "")
            {
                Database.AddChannelMessage(Database.Profile.Id, VM.Model.Code, TextArea.Text, DateTime.Now);
                TextArea.Text = "";
            }
        }

        System.Threading.Timer _timer;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new System.Threading.Timer(new System.Threading.TimerCallback((obj) => Refresh()), null, 0, 1);
        }

        int lastMessageId = 0;

        private async void Refresh()
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            () =>
            {
                int tempId = lastMessageId;
                Database.DatabaseConnection("SELECT id, sender_id, message, datetime FROM Channel_Messages where channel_code = '" + VM.Model.Code + "' and id > " + lastMessageId, () => Database.DataReader(() =>
                {
                    ChannelMessageButton channelMessageButton = new ChannelMessageButton();

                    if (!Database.reader.IsDBNull(1))
                    {
                        Account account = Functions.GetAccount(Database.reader.GetInt32(1));
                        channelMessageButton.AccountName = account.Firstname + " " + account.Lastname;
                        channelMessageButton.ProfilePicture = account.Profilepicture;
                        channelMessageButton.Verified = account.Verified;
                        if (!Database.reader.IsDBNull(3))
                            channelMessageButton.Datetime = Database.reader.GetDateTime(3).ToShortTimeString();
                    }

                    if (!Database.reader.IsDBNull(2))
                    {
                        channelMessageButton.Message = Database.reader.GetString(2);
                    }

                    if (!Database.reader.IsDBNull(0))
                    {
                        lastMessageId = Database.reader.GetInt32(0);
                    }

                    Messages.Children.Add(channelMessageButton);
                }));
                if (lastMessageId > tempId)
                    Content.ChangeView(null, Content.ScrollableHeight, null);
            });
        }
    }
}
