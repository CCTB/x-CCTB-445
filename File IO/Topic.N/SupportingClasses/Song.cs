namespace Topic.N.SupportingClasses
{
    public class Song
    {
        public string Title { get; set; }
        public string SongWriter { get; set; }
        public RunningTime Length { get; set; }

        public Song(string title, string songWriter, RunningTime songLength)
        {
            this.Title = title;
            this.SongWriter = songWriter;
            this.Length = songLength;
        }

        public Song()
        {
        }
    } // end of Song class
}