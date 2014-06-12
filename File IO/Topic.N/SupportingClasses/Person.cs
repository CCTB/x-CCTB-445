using System;
namespace Topic.N.SupportingClasses
{
    public class Person
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrEmpty(value.Trim()))
                    throw new System.Exception("First or last name cannot be blank");
                _firstName = value;
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrEmpty(value.Trim()))
                    throw new System.Exception("First or last name cannot be blank");
                _lastName = value;
            }
        }

        public GenderType Gender { get; private set; }
        public DateTime BirthDate { get; private set; }


        public int Age
        {
            get
            {
                int currentAge = 0;
                DateTime today = new DateTime();
                currentAge = today.Year - BirthDate.Year;
                return currentAge;
            }
        }

        public Person(string firstName, string lastName, GenderType gender, DateTime birthDate)
        {
            if (birthDate.CompareTo(DateTime.Today) > 0)
                throw new System.Exception("Birthdates in the future are not allowed");
            FirstName = firstName;
            LastName = lastName;
            this.Gender = gender;
            this.BirthDate = birthDate;
        }

        public Person()
        {
        }


        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}