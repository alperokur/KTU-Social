using KTU_Social.Controls;
using KTU_Social.Table;
using KTU_Social.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace KTU_Social.View
{
    public sealed partial class HomeView : Grid
    {
        public HomeView()
        {
            InitializeComponent();
            DataContext = VM;
            Functions.UpgradeStrings((string)App.LocalSettings.Values["Language"]);
        }

        public HomeViewModel VM = new HomeViewModel();

        private void Grid_Loading(FrameworkElement sender, object args)
        {
            Database.GetAccountsDB(Database.Accounts);
            Database.GetAccountRollesDB(Database.Account_Rolles);
            Database.GetCategories(Database.Categories);
            Database.GetChannelsDB(Database.Channels);
            Database.GetFriendsDB(Database.Friends);

            if (Database.Profile.Number > 0)
                ProfilePicture.Source = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Profile.Number + ".jpg"));
            else
                ProfilePicture.Source = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Profile.Username + ".jpg"));

            if (Database.Profile.Grade > 0)
                VM.Model.Info = Functions.GetString("GRADE_" + Convert.ToString(Database.Profile.Grade) + "TH_STUDENT");
            else
            {
                switch (Database.Profile.Staff)
                {
                    case 1:
                        VM.Model.Info = Functions.GetString("STAFF_SECRETARY");
                        break;
                    case 2:
                        VM.Model.Info = Functions.GetString("STAFF_ACADEMIC_STAFF");
                        break;
                    case 3:
                        VM.Model.Info = Functions.GetString("STAFF_DEPUTY_HEAD_OF_DEPARTMENT");
                        break;
                    case 4:
                        VM.Model.Info = Functions.GetString("STAFF_HEAD_OF_DEPARTMENT");
                        break;
                }
            }

            if (Database.Profile.Verified > 0)
                VerifiedIcon.Visibility = Visibility.Visible;

            if (Database.Profile.Middlename == null)
                VM.Model.RealName = Database.Profile.Firstname + " " + Database.Profile.Lastname;
            else
                VM.Model.RealName = Database.Profile.Firstname + " " + Database.Profile.Middlename + " " + Database.Profile.Lastname;
            VM.Model.Email = Database.Profile.Email;
            VM.Model.Department = Functions.GetString("DEPARTMENT_" + Database.Profile.Department);

            foreach (var channel in Database.Channels)
            {
                foreach (var account_roll in Database.Account_Rolles)
                {
                    if (Database.Profile.Id == account_roll.Account_id && account_roll.Roll == channel.Code)
                    {
                        ChannelButton channelButton = new ChannelButton();
                        channelButton.ChannelName = Functions.GetString(channel.Code);
                        channelButton.ChannelCode = channel.Code;

                        if (channel.Category == "GRADE_1TH")
                            FirstGrade.Children.Add(channelButton);
                        else if (channel.Category == "GRADE_2TH")
                            SecondGrade.Children.Add(channelButton);
                        else if (channel.Category == "GRADE_3TH")
                            ThirdGrade.Children.Add(channelButton);
                        else if (channel.Category == "GRADE_4TH")
                            FourGrade.Children.Add(channelButton);
                    }
                }
            }

            if (FirstGrade.Children.Count > 0)
                FirstGradeSection.Visibility = Visibility.Visible;

            if (SecondGrade.Children.Count > 0)
                SecondGradeSection.Visibility = Visibility.Visible;

            if (ThirdGrade.Children.Count > 0)
                ThirdGradeSection.Visibility = Visibility.Visible;

            if (FourGrade.Children.Count > 0)
                FourGradeSection.Visibility = Visibility.Visible;

            ObservableCollection<Account> friends = new ObservableCollection<Account>();

            for (int i = 0; i < Database.Accounts.Count; i++)
            {
                for (int j = 0; j < Database.Friends.Count; j++)
                {
                    if (Database.Profile.Id == Database.Friends[j].Account_id && Database.Friends[j].Friend_id == Database.Accounts[i].Id)
                    {
                        friends.Add(Database.Accounts[i]);
                        PersonButton personButton = new PersonButton();
                        if (Database.Accounts[i].Number > 0)
                            personButton.Icon = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Accounts[i].Number + ".jpg"));
                        else
                            personButton.Icon = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Accounts[i].Username + ".jpg"));
                        if (Database.Accounts[i].Verified > 0)
                            personButton.Verified = Visibility.Visible;
                        if (Database.Accounts[i].Middlename == null)
                            personButton.PersonName = Database.Accounts[i].Firstname + " " + Database.Accounts[i].Lastname;
                        else
                            personButton.PersonName = Database.Accounts[i].Firstname + " " + Database.Accounts[i].Middlename + " " + Database.Accounts[i].Lastname;
                        Friends.Children.Add(personButton);
                    }
                }

                if (Database.Profile.Id != Database.Accounts[i].Id)
                {
                    if (Database.Profile.Department == Database.Accounts[i].Department && Database.Accounts[i].Visible > 0)
                    {
                        if (Database.Accounts[i].Staff > 0)
                        {
                            PersonButton personButton = new PersonButton();
                            if (Database.Accounts[i].Avatar > 0)
                            {
                                if (Database.Accounts[i].Number > 0)
                                    personButton.Icon = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Accounts[i].Number + ".jpg"));
                                else
                                    personButton.Icon = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Accounts[i].Username + ".jpg"));
                            }
                            if (Database.Accounts[i].Verified > 0)
                                personButton.Verified = Visibility.Visible;
                            if (Database.Accounts[i].Middlename == null)
                                personButton.PersonName = Database.Accounts[i].Firstname + " " + Database.Accounts[i].Lastname;
                            else
                                personButton.PersonName = Database.Accounts[i].Firstname + " " + Database.Accounts[i].Middlename + " " + Database.Accounts[i].Lastname;
                            DepartmentAcademicStaff.Children.Add(personButton);
                        }
                        else
                        {
                            var result = friends.Where(x => x.Id == Database.Accounts[i].Id);
                            if (result.Count() > 0)
                                continue;
                            else
                            {
                                PersonButton personButton = new PersonButton();
                                if (Database.Accounts[i].Avatar > 0)
                                {
                                    if (Database.Accounts[i].Number > 0)
                                        personButton.Icon = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Accounts[i].Number + ".jpg"));
                                    else
                                        personButton.Icon = new BitmapImage(new Uri("http://" + Database.server + "/accounts/avatars/" + Database.Accounts[i].Username + ".jpg"));
                                }
                                else
                                {

                                }
                                if (Database.Accounts[i].Verified > 0)
                                    personButton.Verified = Visibility.Visible;
                                if (Database.Accounts[i].Middlename == null)
                                    personButton.PersonName = Database.Accounts[i].Firstname + " " + Database.Accounts[i].Lastname;
                                else
                                    personButton.PersonName = Database.Accounts[i].Firstname + " " + Database.Accounts[i].Middlename + " " + Database.Accounts[i].Lastname;
                                PersonInDepartment.Children.Add(personButton);
                            }
                        }
                    }
                }
            }

            if (friends.Count == 0)
            {
                FriendsSection.Visibility = Visibility.Collapsed;
            }
        }

        private string GetSingleRollValue(string query)
        {
            string value = null;
            Database.DatabaseConnection("SELECT roll FROM account_rolles where account_id = " + Database.Profile.Id + " and roll LIKE '" + query + "_%'", () => Database.DataReader(() =>
            {
                if (!Database.reader.IsDBNull(0))
                {
                    var result = from str in Database.Strs where str.Tag == Database.reader.GetString(0) select (string)App.LocalSettings.Values["Language"] == "en" ? str.En : str.Tr;
                    value = result.First();
                }
            }));
            return value;
        }

        private void FirstGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (FirstGrade.Visibility == Visibility.Visible)
                FirstGrade.Visibility = Visibility.Collapsed;
            else
                FirstGrade.Visibility = Visibility.Visible;
        }

        private void SecondGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (SecondGrade.Visibility == Visibility.Visible)
                SecondGrade.Visibility = Visibility.Collapsed;
            else
                SecondGrade.Visibility = Visibility.Visible;
        }

        private void ThirdGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (ThirdGrade.Visibility == Visibility.Visible)
                ThirdGrade.Visibility = Visibility.Collapsed;
            else
                ThirdGrade.Visibility = Visibility.Visible;
        }

        private void FourGradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (FourGrade.Visibility == Visibility.Visible)
                FourGrade.Visibility = Visibility.Collapsed;
            else
                FourGrade.Visibility = Visibility.Visible;
        }

        private void FriendsButton_Click(object sender, RoutedEventArgs e)
        {
            if (Friends.Visibility == Visibility.Visible)
                Friends.Visibility = Visibility.Collapsed;
            else
                Friends.Visibility = Visibility.Visible;
        }

        private void DepartmentAcademicStaffButton_Click(object sender, RoutedEventArgs e)
        {
            if (DepartmentAcademicStaff.Visibility == Visibility.Visible)
                DepartmentAcademicStaff.Visibility = Visibility.Collapsed;
            else
                DepartmentAcademicStaff.Visibility = Visibility.Visible;
        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonInDepartment.Visibility == Visibility.Visible)
                PersonInDepartment.Visibility = Visibility.Collapsed;
            else
                PersonInDepartment.Visibility = Visibility.Visible;
        }
    }
}
