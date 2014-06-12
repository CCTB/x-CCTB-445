using System;
namespace Topic.N.SupportingClasses
{
    public class Student
    {
        #region Properties and Fields
        public GenderType Gender { get; set; }
        public ProgramType ProgramName { get; set; }
        public bool IsFullTime { get; set; }

        private string _name; // The full name of the student
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value) ||
                    string.IsNullOrEmpty(value.Trim()))
                    throw new System.Exception("name cannot be empty");
                _name = value;
            }
        }
        private int _studentId; // The school-provided student ID
        public int StudentId
        {
            get { return _studentId; }
            set
            {
                if (value < 100000000 || value > 999999999)
                    throw new System.Exception("Student Ids must be 9 digits");
                _studentId = value;
            }
        }
        private double _gradePointAverage; // GPA is from 1.0 to 9.0
        public double GradePointAverage
        {
            get { return _gradePointAverage; }
            set
            {
                if (value < 0 || value > 9)
                    throw new System.Exception("GPA must be between 0 and 9 inclusive");
                _gradePointAverage = value;
            }
        }
        #endregion

        #region Constructors
        public Student(string name, GenderType gender, int studentId, ProgramType programName,
                double gradePointAverage, bool fullTime)
        {
            Name = name;
            Gender = gender;
            StudentId = studentId;
            ProgramName = programName;
            GradePointAverage = gradePointAverage;
            IsFullTime = fullTime;
        }

        public Student(string name, GenderType gender, int studentId)
            : this(name, gender, studentId, ProgramType.NONE, 0d, false)
        {
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return "(" + StudentId + ") " + Name;
        }
        #endregion
    }
}