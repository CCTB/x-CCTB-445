using System.Collections.Generic;
using System;
namespace Topic.N.SupportingClasses
{
    public class PhoneBook
    {
        public enum SortOrderType
        {
            NOT_SORTED, PHONE_NUMBER, FIRST_NAME, LAST_NAME
        }

        #region Properties
        public List<PhoneNumber> Numbers { get; set; }
        public SortOrderType SortOrder { get; private set; }
        #endregion

        #region Constructors
        public PhoneBook()
            : this(SortOrderType.NOT_SORTED)
        {
        }

        public PhoneBook(SortOrderType sortOrder)
            : this(new List<PhoneNumber>(), sortOrder)
        {
        }

        public PhoneBook(List<PhoneNumber> phoneNumbers, SortOrderType sortOrder)
        {
            foreach (PhoneNumber entry in phoneNumbers)
            {
                if (entry == null)
                    throw new Exception("Empty entry found in the supplied list of phone numbers");
            }
            this.Numbers = new List<PhoneNumber>(phoneNumbers);
            this.SortOrder = sortOrder;
            Sort();
        }
        #endregion

        #region Private Methods
        private void Sort()
        {
            switch (SortOrder)
            {
                case SortOrderType.FIRST_NAME:
                    Numbers.Sort(ComparePhoneNumbersByFirstName);
                    break;
                case SortOrderType.LAST_NAME:
                    Numbers.Sort(ComparePhoneNumbersByLastName);
                    break;
                case SortOrderType.PHONE_NUMBER:
                    Numbers.Sort(ComparePhoneNumbersByTelephoneNumber);
                    break;
            }
        }

        #region Delegate Methods for Sorting
        private static int ComparePhoneNumbersByFirstName(PhoneNumber first, PhoneNumber second)
        {
            return first.FirstName.CompareTo(second.FirstName);
        }

        private static int ComparePhoneNumbersByLastName(PhoneNumber first, PhoneNumber second)
        {
            return first.LastName.CompareTo(second.LastName);
        }

        private static int ComparePhoneNumbersByTelephoneNumber(PhoneNumber first, PhoneNumber second)
        {
            return first.Number.CompareTo(second.Number);
        }
        #endregion
        #endregion

        #region Public Methods
        /// <summary>
        /// This method changes the sort order of the PhoneBook's Numbers.
        /// </summary>
        /// <param name="sortOrder"></param>
        public void Resort(SortOrderType sortOrder)
        {
            this.SortOrder = sortOrder;
            Sort();
        }

        /// <summary>
        /// This method adds a PhoneNumber to the PhoneBook while preserving the sort order.
        /// </summary>
        /// <param name="entry">A PhoneNumber object to add to the PhoneBook's list of Numbers.</param>
        /// <exception cref="System.Exception">An exception is thrown if the supplied PhoneNumber object is null.</exception>
        /// <exception cref="System.Exception">An exception is thrown if the supplied PhoneNumber's telephone number already exists in the PhoneBook (duplicate telephone numbers are not allowed).</exception>
        public void AddPhoneNumber(PhoneNumber entry)
        {
            if (entry == null)
                throw new Exception("The phone number entry cannot be null");
            if (ReverseLookup(entry.Number) != null)
                throw new Exception("Duplicate phone numbers are not allowed");
            Numbers.Add(entry);
            Sort();
        }

        /// <summary>
        /// Find a PhoneNumber based on the supplied telephone number.
        /// </summary>
        /// <param name="telephoneNumber">A string with the telephone number to search for</param>
        /// <returns>A PhoneNumber object with a matching telephone number, or null if none was found</returns>
        /// <remarks>
        /// This example calls the Find() method of the List<T> class and supplies 
        /// a "lambda expression" to perform. Lambdas have been available since
        /// Visual Studio 2008.
        /// </remarks>
        public PhoneNumber ReverseLookup(string telephoneNumber)
        {
            PhoneNumber found;
            // Tells the list to each element => ("such that") each element's number 
            //                                                 equals the supplied telephone number
            found = Numbers.Find(each => each.Number.Equals(telephoneNumber));
            //                     |  |  \_________________________________/
            //                     |  |   some expression that returns a bool
            //                     |  |
            //                     | "such that"
            //                     |
            //         variable name for each element
            return found;
        }

        public List<PhoneNumber> FindPhoneNumbersByLastName(string lastName)
        {
            List<PhoneNumber> allMatchingEntries;
            allMatchingEntries = Numbers.FindAll(searchEach => searchEach.LastName.Equals(lastName));
            //                                     |        |  \__________________________________/
            //                                     |        |   some expression that returns a bool
            //                                     |        |
            //                                     |    "such that"
            //                                     |
            //                         variable name for each element
            return allMatchingEntries;
        }
        #endregion
    }
}