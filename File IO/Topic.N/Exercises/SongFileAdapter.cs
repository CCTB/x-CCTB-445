using Topic.N.SupportingClasses;
using System;
using System.Collections.Generic;

namespace Topic.N.Exercises
{
    /// <summary>
    /// SongFileAdapter provides a way to read and write
    /// Song information to and from text files.
    /// </summary>
    /// <remarks>
    /// This class requires that the file structure be in the following format:
    /// <ol><li>Title : String
    /// <li>SongWriter : String
    /// <li>Time : String
    /// </ol>
    /// <para>Time must be in the format of "MM:SS".</para>
    /// </remarks>
    public class SongFileAdapter
    {
        #region Read from a file
        public static List<Song> FillList(string filePath, FileFormat format)
        {
            List<Song> data;
            if (format == FileFormat.CSV)
                data = FillList(new CSVFileIO(filePath));
            else
                data = FillList(new XMLFileIO<Song>(filePath));
            return data;
        }

        private static List<Song> FillList(CSVFileIO reader)
        {
            List<Song> data = new List<Song>();
            List<string> lines = reader.ReadAllLines();
            foreach (string individualLine in lines)
            {
                string[] fields = individualLine.Split(',');
                string title, songWriter, time;
                title = fields[0];
                songWriter = fields[1];
                time = fields[2];
                data.Add(new Song(title, songWriter, new RunningTime(time)));
            }
            return data;
        }

        private static List<Song> FillList(XMLFileIO<Song> reader)
        {
            return reader.LoadAll();
        }
        #endregion

        #region Write to a file
        public static void SaveList(List<Song> data, string fileName, FileFormat format, bool append)
        {
            if (format == FileFormat.CSV)
                SaveList(new CSVFileIO(fileName), data, append);
            else
                SaveList(new XMLFileIO<Song>(fileName), data, append);
        }

        private static void SaveList(CSVFileIO writer, List<Song> data, bool append)
        {
            List<string> lines = new List<string>();
            foreach (Song item in data)
            {
                lines.Add(item.Title + "," + item.SongWriter + "," + item.Length.ToString());
            }
            writer.WriteAllLines(lines, append);
        }

        private static void SaveList(XMLFileIO<Song> writer, List<Song> data, bool append)
        {
            writer.SaveAll(data, append);
        }
        #endregion
    }
}