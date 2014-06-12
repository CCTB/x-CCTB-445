using Topic.N.Examples;
using Topic.N.SupportingClasses;
using System.Collections.Generic;
using System;

namespace Topic.N.Drivers
{
    public class DemoBookFileAdapter
    {
        public static void Start(string fileName)
        {
            List<Book> books = BookFileAdapter.LoadList(fileName, FileFormat.CSV);
            DisplayBooks(books);
            BookFileAdapter.SaveList(books, fileName.Replace(".txt", ".xml"), FileFormat.XML, false);
        }

        private static void DisplayBooks(List<Book> books)
        {
            foreach (Book item in books)
            {
                Console.WriteLine("Title  : " + item.Title);
                Console.WriteLine("ISBN   : " + item.Isbn.BarCode);
                Console.WriteLine("Authors: (" + item.Authors.Length + ")");
                foreach (string author in item.Authors)
                    Console.WriteLine("\t\t" + author);
                Console.WriteLine();
            }
        }
    }
}