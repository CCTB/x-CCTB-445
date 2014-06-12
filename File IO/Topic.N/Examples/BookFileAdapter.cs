using Topic.N.SupportingClasses;
using System.Collections.Generic;

namespace Topic.N.Examples
{
    /// <summary>
    /// BookFileAdapter provides a way to read and write
    /// Book information to and from text files.
    /// </summary>
    /// <remarks>
    /// This class requires that the CSV file structure be in the following format:
    /// <ol><li>Title : String
    /// <li>Authors : String[]
    /// <ol><li>The Author information is a semicolon (;) separated list of authors
    /// </li></ol>
    /// <li>Publication Year : Integer
    /// <li>Publisher : String
    /// <li>Format : String
    /// <li>Dewey Decimal Number : String
    /// <li>ISBN : String
    /// <li>Number of Pages : Integer
    /// <li>Cover Price : Money
    /// </ol>
    /// <para>
    /// This method fills a List of Book data. Each Book only needs
    /// the title, the authors (as an array of Strings), and the ISBN. 
    /// Therefore, the other data in the file will simply be discarded as it
    /// is read. In the file, the Author information is a semicolon (;)
    /// separated list of authors.
    /// </para>
    /// </remarks>
    public class BookFileAdapter
    {
        #region Read from a file
        public static List<Book> LoadList(string filePath, FileFormat format)
        {
            List<Book> data;
            if (format == FileFormat.CSV)
                data = LoadList(new CSVFileIO(filePath));
            else
                data = LoadList(new XMLFileIO<Book>(filePath));
            return data;
        }

        private static List<Book> LoadList(CSVFileIO reader)
        {
            List<Book> data = new List<Book>();
            List<string> lines = reader.ReadAllLines();
            foreach (string individualLine in lines)
            {
            }
            return data;
        }

        private static List<Book> LoadList(XMLFileIO<Book> reader)
        {
            return reader.LoadAll();
        }
        #endregion

        #region Write to a file
        public static void SaveList(List<Book> data, string fileName, FileFormat format, bool append)
        {
            if (format == FileFormat.CSV)
                SaveList(new CSVFileIO(fileName), data, append);
            else
                SaveList(new XMLFileIO<Book>(fileName), data, append);
        }

        private static void SaveList(CSVFileIO writer, List<Book> data, bool append)
        {
            List<string> lines = new List<string>();
            foreach (Book item in data)
            {
            }
            writer.WriteAllLines(lines, append);
        }

        private static void SaveList(XMLFileIO<Book> writer, List<Book> data, bool append)
        {
            writer.SaveAll(data, append);
        }
        #endregion
    }
}