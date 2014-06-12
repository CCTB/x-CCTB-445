using System.IO;
using System;
using Topic.N.SupportingClasses;
using System.Collections.Generic;

namespace Topic.N.Exercises
{
    /// <summary>
    /// PersonFileAdapter provides a way to read and write
    /// Person information to and from text files.
    /// </summary>
    /// <remarks>
    /// This class requires that the file structure be in the following format:
    /// <ol><li>FirstName : String
    /// <li>LastName : String
    /// <li>Gender : GenderType
    /// <li>Birthdate : Date
    /// </ol>
    /// The GenderType must be the gender type as a string. Likewise, the Date is
    /// stored as a string.
    /// </remarks>
    public class PersonFileAdapter
    {
        #region Read from a file
        public static List<Person> LoadList(string filePath, FileFormat format)
        {
            List<Person> data;
            if (format == FileFormat.CSV)
                data = LoadList(new CSVFileIO(filePath));
            else
                data = LoadList(new XMLFileIO<Person>(filePath));
            return data;
        }

        private static List<Person> LoadList(CSVFileIO reader)
        {
            List<Person> data = new List<Person>();
            List<string> lines = reader.ReadAllLines();
            foreach (string individualLine in lines)
            {
            }
            return data;
        }

        private static List<Person> LoadList(XMLFileIO<Person> reader)
        {
            return null;
        }
        #endregion

        #region Write to a file
        public static void SaveList(List<Person> data, string fileName, FileFormat format, bool append)
        {
            if (format == FileFormat.CSV)
                SaveList(new CSVFileIO(fileName), data, append);
            else
                SaveList(new XMLFileIO<Person>(fileName), data, append);
        }

        private static void SaveList(CSVFileIO writer, List<Person> data, bool append)
        {
            List<string> lines = new List<string>();
            foreach (Person item in data)
            {
            }
            writer.WriteAllLines(lines, append);
        }

        private static void SaveList(XMLFileIO<Person> writer, List<Person> data, bool append)
        {
        }
        #endregion
    }
}