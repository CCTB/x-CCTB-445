using System.IO;
using Topic.N.SupportingClasses;
using System.Collections.Generic;

namespace Topic.N.Examples
{
    /// <summary>
    /// PhoneNumberFileAdapter provides a way to read and write 
    /// PhoneNumber information to and from text files.
    /// </summary>
    /// <remarks>
    /// This class requires that the file structure be in the following format:
    /// <ol><li>FirstName : String
    /// <li>LastName : String
    /// <li>Number : String
    /// </ol>
    /// </remarks>
    public class PhoneNumberFileAdapter
    {
        #region Reading from a file
        public static List<PhoneNumber> LoadList(string filePath, FileFormat format)
        {
            List<PhoneNumber> data;
            if (format == FileFormat.CSV)
                data = LoadList(new CSVFileIO(filePath));
            else
                data = LoadList(new XMLFileIO<PhoneNumber>(filePath));
            return data;
        }

        private static List<PhoneNumber> LoadList(CSVFileIO reader)
        {
            List<PhoneNumber> data = new List<PhoneNumber>();
            List<string> lines = reader.ReadAllLines();
            return data;
        }

        private static List<PhoneNumber> LoadList(XMLFileIO<PhoneNumber> reader)
        {
            return reader.LoadAll();
        }
        #endregion

        #region Write to a file
        public static void SaveList(List<PhoneNumber> data, string fileName, FileFormat format, bool append)
        {
            if (format == FileFormat.CSV)
                SaveList(new CSVFileIO(fileName), data, append);
            else
                SaveList(new XMLFileIO<PhoneNumber>(fileName), data, append);
        }

        private static void SaveList(CSVFileIO writer, List<PhoneNumber> data, bool append)
        {
            List<string> lines = new List<string>();
            writer.WriteAllLines(lines, append);
        }

        private static void SaveList(XMLFileIO<PhoneNumber> writer, List<PhoneNumber> data, bool append)
        {
            writer.SaveAll(data, append);
        }
        #endregion
    }
}