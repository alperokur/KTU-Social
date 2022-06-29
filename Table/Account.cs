using System;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace KTU_Social.Table
{
    public class Account : INotifyPropertyChanged
    {
        private int _id;
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(nameof(Id)); } }

        private string _username;
        public string Username { get { return _username; } set { _username = value; OnPropertyChanged(nameof(Username)); } }

        private string _password;
        public string Password { get { return _password; } set { _password = value; OnPropertyChanged(nameof(Password)); } }

        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(nameof(Email)); } }

        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(nameof(Phone)); } }

        private string _firstname;
        public string Firstname { get { return _firstname; } set { _firstname = value; OnPropertyChanged(nameof(Firstname)); } }

        private string _middlename;
        public string Middlename { get { return _middlename; } set { _middlename = value; OnPropertyChanged(nameof(Middlename)); } }

        private string _lastname;
        public string Lastname { get { return _lastname; } set { _lastname = value; OnPropertyChanged(nameof(Lastname)); } }

        private DateTime _birthdate;
        public DateTime Birthdate { get { return _birthdate; } set { _birthdate = value; OnPropertyChanged(nameof(Birthdate)); } }

        private int _number;
        public int Number { get { return _number; } set { _number = value; OnPropertyChanged(nameof(Number)); } }

        private string _department;
        public string Department { get { return _department; } set { _department = value; OnPropertyChanged(nameof(Department)); } }

        private int _grade;
        public int Grade { get { return _grade; } set { _grade = value; OnPropertyChanged(nameof(Grade)); } }

        private int _degree;
        public int Degree { get { return _degree; } set { _degree = value; OnPropertyChanged(nameof(Degree)); } }

        private int _verified;
        public int Verified { get { return _verified; } set { _verified = value; OnPropertyChanged(nameof(Verified)); } }

        private int _staff;
        public int Staff { get { return _staff; } set { _staff = value; OnPropertyChanged(nameof(Staff)); } }

        private int _avatar;
        public int Avatar { get { return _avatar; } set { _avatar = value; OnPropertyChanged(nameof(Avatar)); } }

        private int _visible;
        public int Visible { get { return _visible; } set { _visible = value; OnPropertyChanged(nameof(Visible)); } }

        private ImageSource _profilepicture;
        public ImageSource Profilepicture { get { return _profilepicture; } set { _profilepicture = value; OnPropertyChanged(nameof(Profilepicture)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
