using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMSample.Split
{
    public class PersonViewModel
    {
        public ObservableCollection<Person> PersonCollection;

        public PersonViewModel()
        {
            PersonCollection = new ObservableCollection<Person>();
        }

        public async Task GetPersonDataFromWebAsync()
        {
            string url = "xxxx";

            await Task.Delay(1000);

            var mockData = new List<Person>
            {
                new Person("Male",0),
                new Person("Female",1)
            };

            PersonCollection.Clear();
            foreach (var person in mockData)
            {
                PersonCollection.Add(person);
            }
        }
    }
}
