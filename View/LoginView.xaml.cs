using KTU_Social.Table;
using KTU_Social.ViewModel;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KTU_Social.View
{
    public sealed partial class LoginView : Grid
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = VM;
        }

        public LoginViewModel VM = new LoginViewModel();

        public HomeView home;

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            string lang = (string)App.LocalSettings.Values["Language"] == "en" ? "tr" : "en";
            Functions.UpgradeStrings(lang);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text != "" & Password.Password != "")
            {
                Database.DatabaseConnection("Select * From Accounts where (username = '" + Username.Text + "' or email = '" + Username.Text + "') and password = '" + Functions.MD5Hash(Password.Password) + "'", () => Database.DataReader(() =>
                {
                    Database.Profile = new Account();

                    if (!Database.reader.IsDBNull(0))
                        Database.Profile.Id = Database.reader.GetInt32(0);

                    if (!Database.reader.IsDBNull(1))
                        Database.Profile.Username = Database.reader.GetString(1);

                    if (!Database.reader.IsDBNull(2))
                        Database.Profile.Password = Database.reader.GetString(2);

                    if (!Database.reader.IsDBNull(3))
                        Database.Profile.Email = Database.reader.GetString(3);

                    if (!Database.reader.IsDBNull(4))
                        Database.Profile.Phone = Database.reader.GetString(4);

                    if (!Database.reader.IsDBNull(5))
                        Database.Profile.Firstname = Database.reader.GetString(5);

                    if (!Database.reader.IsDBNull(6))
                        Database.Profile.Middlename = Database.reader.GetString(6);

                    if (!Database.reader.IsDBNull(7))
                        Database.Profile.Lastname = Database.reader.GetString(7);

                    if (!Database.reader.IsDBNull(8))
                        Database.Profile.Birthdate = Database.reader.GetDateTime(8);

                    if (!Database.reader.IsDBNull(9))
                        Database.Profile.Number = Database.reader.GetInt32(9);

                    if (!Database.reader.IsDBNull(10))
                        Database.Profile.Department = Database.reader.GetString(10);

                    if (!Database.reader.IsDBNull(11))
                        Database.Profile.Grade = Database.reader.GetInt32(11);

                    if (!Database.reader.IsDBNull(12))
                        Database.Profile.Degree = Database.reader.GetInt32(12);

                    if (!Database.reader.IsDBNull(13))
                        Database.Profile.Verified = Database.reader.GetInt32(13);

                    if (!Database.reader.IsDBNull(14))
                        Database.Profile.Staff = Database.reader.GetInt32(14);

                    if (!Database.reader.IsDBNull(15))
                        Database.Profile.Avatar = Database.reader.GetInt32(15);

                    if (!Database.reader.IsDBNull(16))
                        Database.Profile.Visible = Database.reader.GetInt32(16);
                }));

                if (Database.Profile != null)
                {
                    if (RememberMe.IsChecked == true)
                    {
                        App.LocalSettings.Values["Username"] = Username.Text;
                        App.LocalSettings.Values["Password"] = Password.Password;
                        App.LocalSettings.Values["RememberMe"] = true;
                    }
                    else
                    {
                        App.LocalSettings.Values["Password"] = null;
                        App.LocalSettings.Values["RememberMe"] = false;
                    }

                    App.view.Children.Remove(this);
                    home = new HomeView
                    {
                        Name = "HomeView"
                    };
                    Functions.UpgradeStrings((string)App.LocalSettings.Values["Language"]);
                    App.view.Children.Add(home);
                }
                else
                {
                    App.LocalSettings.Values["Password"] = null;
                    App.LocalSettings.Values["RememberMe"] = false;
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.LocalSettings.Values["Username"] != null)
                Username.Text = (string)App.LocalSettings.Values["Username"];

            if (Convert.ToBoolean(App.LocalSettings.Values["RememberMe"]) == false)
            {
                if (App.LocalSettings.Values["Username"] != null)
                    Password.Focus(FocusState.Programmatic);
                else
                    Username.Focus(FocusState.Programmatic);
                RememberMe.IsChecked = false;
                Password.Password = "";
            }
            else
            {
                LoginButton.Focus(FocusState.Programmatic);
                RememberMe.IsChecked = true;
                Password.Password = (string)App.LocalSettings.Values["Password"];
            }
        }
    }
}
