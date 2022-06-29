using KTU_Social.Table;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KTU_Social
{
    internal class Functions
    {
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public static Account GetAccount(int id)
        {
            var result = Database.Accounts.Where(account => account.Id == id);
            return result.FirstOrDefault();
        }

        public static string GetString(string tag)
        {
            var result = from str in Database.Strs.Where(str => str.Tag == tag) select (string)App.LocalSettings.Values["Language"] == "en" ? str.En : str.Tr;
            return result.FirstOrDefault();
        }

        public static string GetTime(DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH':'mm':'ss");
        }

        public static string SetString(string lang, string tag)
        {
            var result = from str in Database.Strs.Where(str => str.Tag == tag) select lang == "en" ? str.En : str.Tr;
            return result.FirstOrDefault();
        }

        public static void UpgradeStrings(string lang)
        {
            App.mainPage.VM.Title = SetString(lang, "UNIVERSITY_NAME");
            App.login.VM.Model.Welcome = SetString(lang, "LOGINVIEW_WELCOME");
            App.login.VM.Model.Info = SetString(lang, "LOGINVIEW_INFO");
            App.login.VM.Model.Username = SetString(lang, "LOGINVIEW_EMAIL");
            App.login.VM.Model.Password = SetString(lang, "LOGINVIEW_PASSWORD");
            App.login.VM.Model.RememberMe = SetString(lang, "LOGINVIEW_REMEMBERME");
            App.login.VM.Model.LoginText = SetString(lang, "LOGINVIEW_LOGIN");

            if (App.login.home != null)
            {
                App.login.home.VM.Model.Department = SetString(lang, Database.Profile.Department);
                App.login.home.VM.Model.Friends = SetString(lang, "HOMEVIEW_FRIENDS");
                App.login.home.VM.Model.Department_Academic_Staff = SetString(lang, "HOMEVIEW_DEPARTMENT_ACADEMIC_STAFF");
                App.login.home.VM.Model.FirstGrade = SetString(lang, "GRADE_1TH");
                App.login.home.VM.Model.SecondGrade = SetString(lang, "GRADE_2TH");
                App.login.home.VM.Model.ThirdGrade = SetString(lang, "GRADE_3TH");
                App.login.home.VM.Model.FourGrade = SetString(lang, "GRADE_4TH");
            }

            App.LocalSettings.Values["Language"] = lang;
        }

        public static void UpgradeAccounts()
        {
            Database.Accounts.Clear();
            Database.GetAccountsDB(Database.Accounts);
        }

        public static void UpgradeAccountRolles()
        {
            Database.Account_Rolles.Clear();
            Database.GetAccountRollesDB(Database.Account_Rolles);
        }

        public static void UpgradeFriends()
        {
            Database.Friends.Clear();
            Database.GetFriendsDB(Database.Friends);
        }
    }
}
