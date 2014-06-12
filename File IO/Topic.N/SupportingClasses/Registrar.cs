using System.Collections.Generic;
using System;
namespace Topic.N.SupportingClasses
{
    public class Registrar
    {
        // public get ReadOnly version
        private List<Student> studentBody;
        private int MaxEnrollmentAllowed { get; set; }
        public int Count { get { return studentBody.Count; } }

        // double-underscores are a clue to the programmer that 
        // this value should never be made "accessible" outside 
        // this class (old C/C++ standards)
        private static int __NextStudentId = 200800001;

        public Registrar(int maxStudents)
        {
            if (maxStudents <= 0)
                throw new System.Exception("The maximum enrollment allowed must be greater than zero");
            MaxEnrollmentAllowed = maxStudents;
            studentBody = new List<Student>();
        }

        public Registrar() : this(1000)
        {
        }

        public int ProgramEnrollment(ProgramType program)
        {
            int count = 0;
            foreach (Student aStudent in studentBody)
                if (aStudent != null)
                    if (aStudent.ProgramName == program)
                        count++;
            return count;
        }

        public int Add(Person newStudent, ProgramType programOfStudy, bool fullTime)
        {
            if (Count == MaxEnrollmentAllowed)
                throw new Exception("Maximum allowed registrations have been reached; no new students can be added");

            int studentId = __NextStudentId;
            Student info = new Student(newStudent.ToString(), newStudent.Gender, studentId,
                    programOfStudy, 0.0, fullTime);
            studentBody.Add(info);
            __NextStudentId++;
            return studentId;
        }

        public Student FindStudent(int id)
        {
            Student foundStudent = studentBody.Find(theStudent => theStudent.StudentId == id);
            return foundStudent;
        }

        public Student RemoveStudent(int id)
        {
            Student foundStudent = FindStudent(id);
            studentBody.Remove(foundStudent);
            return foundStudent;
        }

        public void SwitchProgram(int id, ProgramType programOfStudy)
        {
            Student found = FindStudent(id);
            if (found == null)
                throw new System.Exception("Cannot switch programs: Student does not exist");
            if (found.ProgramName == programOfStudy)
                throw new System.Exception("Student is already enrolled in the program of study");
            found.ProgramName=programOfStudy;
        }
    }
}