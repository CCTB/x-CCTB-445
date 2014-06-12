using System;
namespace Topic.N.SupportingClasses
{
    public class PhoneNumber
    {
        #region Properties and Fields
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
                    throw new System.Exception("First name cannot be empty");
                _FirstName = value.Trim();
            }
        }
        private string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
                    throw new System.Exception("Last name cannot be empty");
                _LastName = value.Trim();
            }
        }
        private string _Number;
        public string Number
        {
            get { return _Number; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(value.Trim()))
                    throw new System.Exception("Number cannot be empty");
                _Number = value.Trim();
            }
        }
        #endregion

        #region Constructors
        public PhoneNumber(string firstName, string lastName, string number)
        {
            FirstName = firstName;
            LastName = lastName;
            Number = number;
        }

        public PhoneNumber()
        {
        }
        #endregion
    }
}