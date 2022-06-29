using System.ComponentModel;

namespace KTU_Social.Model
{
    public class Home : INotifyPropertyChanged
    {
        private string _realName;
        public string RealName { get { return _realName; } set { _realName = value; OnPropertyChanged(nameof(RealName)); } }

        private string _email;
        public string Email { get { return _email; } set { _email = value; OnPropertyChanged(nameof(Email)); } }

        private string _depoartment;
        public string Department { get { return _depoartment; } set { _depoartment = value; OnPropertyChanged(nameof(Department)); } }

        private string _info;
        public string Info { get { return _info; } set { _info = value; OnPropertyChanged(nameof(Info)); } }

        private string _firstGrade;
        public string FirstGrade { get { return _firstGrade; } set { _firstGrade = value; OnPropertyChanged(nameof(FirstGrade)); } }

        private string _secondGrade;
        public string SecondGrade { get { return _secondGrade; } set { _secondGrade = value; OnPropertyChanged(nameof(SecondGrade)); } }

        private string _thirdGrade;
        public string ThirdGrade { get { return _thirdGrade; } set { _thirdGrade = value; OnPropertyChanged(nameof(ThirdGrade)); } }

        private string _fourGrade;
        public string FourGrade { get { return _fourGrade; } set { _fourGrade = value; OnPropertyChanged(nameof(FourGrade)); } }

        private string _friends;
        public string Friends { get { return _friends; } set { _friends = value; OnPropertyChanged(nameof(Friends)); } }

        private string _department_Academic_Staff;
        public string Department_Academic_Staff { get { return _department_Academic_Staff; } set { _department_Academic_Staff = value; OnPropertyChanged(nameof(Department_Academic_Staff)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}