namespace MVVMSample.Split
{
    public class Person
    {
        public string Name { get; set; }
        public int Gender { get; set; }
        internal Person() { }

        public Person(string name,int gender)
        {
            this.Name = name;
            this.Gender = gender;
        }
    }
}
