

namespace Topic.N.SupportingClasses
{
    public class RunningTime
    {
        #region Properties
        private int _Minutes;
        public int Minutes
        {
            get { return _Minutes; }
            set
            {
                if (value < 0)
                    throw new System.Exception("Negative minutes not allowed");
                _Minutes = value;
            }
        }
        private int _Seconds;
        public int Seconds
        {
            get { return _Seconds; }
            set
            {
                if (value < 0)
                    throw new System.Exception("Negative seconds not allowed");
                if (value > 59)
                    throw new System.Exception("Seconds cannot be over 59");
                _Seconds = value;
            }
        }
        public int TotalSeconds { get { return Minutes * 60 + Seconds; } }
        #endregion

        #region Constructors
        public RunningTime(int minutes, int seconds)
        {
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public RunningTime(string time)
        {
            string[] timeParts = time.Split(':');
            Minutes = int.Parse(timeParts[0]);
            Seconds = int.Parse(timeParts[1]);
        }

        public RunningTime()
        {
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            string time = Minutes + ":" + PaddZero(Seconds);
            return time;
        }
        #endregion

        #region Private (helper) Methods
        private static string PaddZero(int value)
        {
            string text;
            if (value < 10)
                text = "0" + value.ToString();
            else
                text = value.ToString();
            return text;
        }
        #endregion
    }
}