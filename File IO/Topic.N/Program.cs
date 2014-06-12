using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Topic.N.Drivers;

namespace Topic.N
{
    class Program
    {
        private const string STR_Resources = @"Resources\";
        private const string STR_PhoneList_22817txt = STR_Resources + "PhoneList_22817.txt";
        private const string STR_BookListtxt = STR_Resources + "BookList.txt";

        static void Main(string[] args)
        {
            try
            {
                CityPhoneDirectory.Start(STR_PhoneList_22817txt);
                DemoBookFileAdapter.Start(STR_BookListtxt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
