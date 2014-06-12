using System.IO;
using Topic.N.Examples;
using Topic.N.SupportingClasses;
using System;
using System.Collections.Generic;

namespace Topic.N.Drivers
{
    public class CityPhoneDirectory
    {
        public static void Start(string fileName)
        {
            PhoneBook shoreWoodPark = new PhoneBook(PhoneNumberFileAdapter.LoadList(fileName, FileFormat.CSV), PhoneBook.SortOrderType.NOT_SORTED);
            DisplayPhoneBook(shoreWoodPark);
            shoreWoodPark.Resort(PhoneBook.SortOrderType.LAST_NAME);
            DisplayPhoneBook(shoreWoodPark);
            PhoneNumberFileAdapter.SaveList(shoreWoodPark.Numbers, fileName.Replace(".txt", ".xml"), FileFormat.XML, false);
        }

        private static void DisplayPhoneBook(PhoneBook whitePages)
        {
            Console.WriteLine("White Pages");
            Console.WriteLine("===========");
            foreach (PhoneNumber number in whitePages.Numbers)
                Console.WriteLine("new PhoneNumber(\"" + number.FirstName + "\", \"" + number.LastName + "\", \"" + number.Number + "\"),");
        }
    }
}