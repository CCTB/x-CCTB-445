using System.IO;


using Topic.N.SupportingClasses;
using System.Collections.Generic;
using System;

namespace Topic.N.Examples
{
    /// <summary>
    /// SafetyDepositBoxFileAdapter provides a way to read and write 
    /// SafetyDepositBox information to and from text files.
    /// </summary>
    /// <remarks>
    /// This class requires that the file structure be in the following format:
    /// <ol><li>BoxNumber : Integer
    /// <li>AccountNumber : Integer (Optional)
    /// </ol>
    /// </remarks>
    public class SafetyDepositBoxFileAdapter
    {
        #region Read from a file
        public static List<SafetyDepositBox> LoadList(string filePath, FileFormat format)
        {
            List<SafetyDepositBox> data;
            if (format == FileFormat.CSV)
                data = LoadList(new CSVFileIO(filePath));
            else
                data = LoadList(new XMLFileIO<SafetyDepositBox>(filePath));
            return data;
        }

        private static List<SafetyDepositBox> LoadList(CSVFileIO reader)
        {
            List<SafetyDepositBox> data = new List<SafetyDepositBox>();
            List<string> lines = reader.ReadAllLines();
            foreach (string individualLine in lines)
            {
                // code specifics here..
                string[] fields = individualLine.Split(',');
                int boxNumber, accountNumber;
                boxNumber = Convert.ToInt32(fields[0]);
                if (fields.Length > 1)
                {
                    accountNumber = Convert.ToInt32(fields[1]);
                    data.Add(new SafetyDepositBox(boxNumber, accountNumber));
                }
                else
                {
                    data.Add(new SafetyDepositBox(boxNumber));
                }
            }
            return data;
        }

        private static List<SafetyDepositBox> LoadList(XMLFileIO<SafetyDepositBox> reader)
        {
            return reader.LoadAll();
        }
        #endregion

        #region Write to a file
        public static void SaveList(List<SafetyDepositBox> data, string fileName, FileFormat format, bool append)
        {
            if (format == FileFormat.CSV)
                SaveList(new CSVFileIO(fileName), data, append);
            else
                SaveList(new XMLFileIO<SafetyDepositBox>(fileName), data, append);
        }

        private static void SaveList(CSVFileIO writer, List<SafetyDepositBox> data, bool append)
        {
            List<string> lines = new List<string>();
            foreach (SafetyDepositBox item in data)
            {
                string lineOfText = item.BoxNumber.ToString();
                if (item.IsLeased)
                    lineOfText += "," + item.AccountNumber;
                lines.Add(lineOfText);
            }
            writer.WriteAllLines(lines, append);
        }

        private static void SaveList(XMLFileIO<SafetyDepositBox> writer, List<SafetyDepositBox> data, bool append)
        {
            writer.SaveAll(data, append);
        }
        #endregion
    }
}