using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MVVMSample.Standard
{
    public class PersonViewModel:INotifyPropertyChanged
    {
        private Person _person;

        public PersonViewModel(Person person)
        {
            this._person = person;
        }

        #region Properties
        public Brush GenderBrush
        {
            get => GetPersonGenderBrush();
        }
        public string GenderString
        {
            get => GetPersonGenderString();
        }
        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                OnProeprtyChanged();
            }
        }

        
        #endregion

        #region Methods
        private Brush GetPersonGenderBrush()
        {
            if (_person.Gender == 0)
            {
                return new SolidColorBrush(Colors.Blue);
            }
            else
            {
                return new SolidColorBrush(Colors.Red);
            }
        }

        private string GetPersonGenderString()
        {
            if (_person.Gender == 0)
            {
                return "Male";
            }
            else
            {
                return "Female";
            }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnProeprtyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
