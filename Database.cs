using KTU_Social.Table;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace KTU_Social
{
    public class Database
    {
        public static readonly string server = "localhost", dbname = "KTU", dbuser = "root", dbpass = "";

        public static SqlDataReader reader;
        public static SqlCommand command;

        public static readonly ObservableCollection<Account> Accounts = new ObservableCollection<Account>();
        public static readonly ObservableCollection<Account_Roll> Account_Rolles = new ObservableCollection<Account_Roll>();
        public static readonly ObservableCollection<Category> Categories = new ObservableCollection<Category>();
        public static readonly ObservableCollection<Channel> Channels = new ObservableCollection<Channel>();
        public static readonly ObservableCollection<Friend> Friends = new ObservableCollection<Friend>();
        public static readonly ObservableCollection<Str> Strs = new ObservableCollection<Str>();

        public static ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;

        public static Account Profile;

        public Database()
        {
            GetStringsDB(Strs);

            if ((string)LocalSettings.Values["Language"] == null)
                Functions.UpgradeStrings("tr");
            else
                Functions.UpgradeStrings((string)LocalSettings.Values["Language"]);
        }

        public static void DatabaseConnection(string query, Action action)
        {
            string connectionString = @"Data Source = " + server + "; Initial Catalog =  " + dbname + "; User ID = " + dbuser + "; Password = " + dbpass;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (command = new SqlCommand(query, connection))
                {
                    action();
                }
            }
        }

        public static void DataReader(Action action)
        {
            using (reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    action();
                }
            }
        }

        public static void ExecuteNonQuery()
        {
            command.ExecuteNonQuery();
        }

        public static void GetAccountsDB(ObservableCollection<Account> list)
        {
            DatabaseConnection("SELECT * FROM Accounts ORDER BY firstname, middlename, lastname ASC", () => DataReader(() =>
            {
                Account account = new Account();

                if (!reader.IsDBNull(0))
                    account.Id = reader.GetInt32(0);

                if (!reader.IsDBNull(1))
                    account.Username = reader.GetString(1);

                if (!reader.IsDBNull(2))
                    account.Password = reader.GetString(2);

                if (!reader.IsDBNull(3))
                    account.Email = reader.GetString(3);

                if (!reader.IsDBNull(4))
                    account.Phone = reader.GetString(4);

                if (!reader.IsDBNull(5))
                    account.Firstname = reader.GetString(5);

                if (!reader.IsDBNull(6))
                    account.Middlename = reader.GetString(6);

                if (!reader.IsDBNull(7))
                    account.Lastname = reader.GetString(7);

                if (!reader.IsDBNull(8))
                    account.Birthdate = reader.GetDateTime(8);

                if (!reader.IsDBNull(9))
                    account.Number = reader.GetInt32(9);

                if (!reader.IsDBNull(10))
                    account.Department = reader.GetString(10);

                if (!reader.IsDBNull(11))
                    account.Grade = reader.GetInt32(11);

                if (!reader.IsDBNull(12))
                    account.Degree = reader.GetInt32(12);

                if (!reader.IsDBNull(13))
                    account.Verified = reader.GetInt32(13);

                if (!reader.IsDBNull(14))
                    account.Staff = reader.GetInt32(14);

                if (!reader.IsDBNull(15))
                    account.Avatar = reader.GetInt32(15);

                if (!reader.IsDBNull(16))
                    account.Visible = reader.GetInt32(16);

                if (account.Number > 0)
                    account.Profilepicture = new BitmapImage(new Uri("http://" + server + "/accounts/avatars/" + account.Number + ".jpg"));
                else
                    account.Profilepicture = new BitmapImage(new Uri("http://" + server + "/accounts/avatars/" + account.Username + ".jpg"));

                list.Add(account);
            }));
        }

        public static void GetAccountRollesDB(ObservableCollection<Account_Roll> list)
        {
            DatabaseConnection("SELECT * FROM Account_Rolles", () => DataReader(() =>
            {
                Account_Roll account_roll = new Account_Roll();

                if (!reader.IsDBNull(0))
                    account_roll.Account_id = reader.GetInt32(0);

                if (!reader.IsDBNull(1))
                    account_roll.Roll = reader.GetString(1);

                list.Add(account_roll);
            }));
        }

        public static void GetCategories(ObservableCollection<Category> list)
        {
            DatabaseConnection("SELECT code, priority FROM Categories INNER JOIN Strings on Categories.code = Strings.tag ORDER BY Strings." + App.LocalSettings.Values["Language"] + " ASC", () => DataReader(() =>
            {
                Category category = new Category();

                if (!reader.IsDBNull(0))
                    category.Code = reader.GetString(0);

                if (!reader.IsDBNull(1))
                    category.Priority = reader.GetInt32(1);

                list.Add(category);
            }));
        }

        public static void GetChannelsDB(ObservableCollection<Channel> list)
        {
            DatabaseConnection("SELECT code, category, period, degree FROM Channels INNER JOIN Strings on Channels.code = Strings.tag ORDER BY Strings." + App.LocalSettings.Values["Language"] + " ASC", () => DataReader(() =>
            {
                Channel channel = new Channel();

                if (!reader.IsDBNull(0))
                    channel.Code = reader.GetString(0);

                if (!reader.IsDBNull(1))
                    channel.Category = reader.GetString(1);

                if (!reader.IsDBNull(2))
                    channel.Period = reader.GetInt32(2);

                if (!reader.IsDBNull(3))
                    channel.Degree = reader.GetInt32(3);

                list.Add(channel);
            }));
        }

        public static void GetFriendsDB(ObservableCollection<Friend> list)
        {
            DatabaseConnection("SELECT * FROM Friends", () => DataReader(() =>
            {
                Friend friend = new Friend();

                if (!reader.IsDBNull(0))
                    friend.Account_id = reader.GetInt32(0);

                if (!reader.IsDBNull(1))
                    friend.Friend_id = reader.GetInt32(1);

                list.Add(friend);
            }));
        }

        public static void GetStringsDB(ObservableCollection<Str> list)
        {
            DatabaseConnection("SELECT * FROM Strings", () => DataReader(() =>
            {
                Str str = new Str();

                if (!reader.IsDBNull(0))
                    str.Tag = reader.GetString(0);

                if (!reader.IsDBNull(1))
                    str.En = reader.GetString(1);

                if (!reader.IsDBNull(2))
                    str.Tr = reader.GetString(2);

                list.Add(str);
            }));
        }

        //public static void AddChannelMessage(int sender_id, string channel_code, string message, DateTime datetime)
        //{
        //    DatabaseConnection(
        //        "INSERT INTO Channel_Messages (sender_id, channel_id, message, datetime) " +
        //        "VALUES (" + sender_id + ", '" + channel_code + "', '" + message + "', " + datetime + ")", 
        //        () => ExecuteNonQuery());
        //}

        public static void AddChannelMessage(int sender_id, string channel_code, string message, DateTime datetime)
        {
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDate = datetime.ToString(format);
            var convertedBack = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);
            DatabaseConnection(
                "INSERT INTO Channel_Messages (sender_id, channel_code, message, datetime) " +
                "VALUES (" + sender_id + ", '" + channel_code + "', '" + message + "', '" + convertedBack + "')",
                () => ExecuteNonQuery());
        }
    }
}
