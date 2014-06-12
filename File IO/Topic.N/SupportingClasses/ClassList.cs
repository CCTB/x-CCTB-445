using System;
namespace Topic.N.SupportingClasses
{
    public class ClassList
    {
        public const int CLASS_LIMIT = 25;
        public string CourseId { get; private set; }
        public Student[] Students { get; private set; }
        public int ClassSize { get; private set; }

        public ClassList(string courseId) :
            this(courseId, new Student[CLASS_LIMIT])
        {
        }

        public ClassList(string courseId, Student[] existingStudentList)
        {
            if (string.IsNullOrEmpty(courseId) || string.IsNullOrEmpty(courseId.Trim()))
                throw new Exception("Course Id is required");
            if (existingStudentList == null)
                throw new Exception("Students cannot be a null list");
            if (existingStudentList.Length > CLASS_LIMIT)
                throw new Exception("Class Limit Exceeded");
            CopyClassList(existingStudentList);
            CheckforDuplicates();
            this.CourseId = courseId.Trim();
        }

        private void CopyClassList(Student[] students)
        {
            ClassSize = 0;
            this.Students = new Student[CLASS_LIMIT];
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null)
                {
                    this.Students[ClassSize] = students[i];
                    ClassSize++;
                }
                else
                    break; // Treat the first null instance as a "flag" indicating the end of actual student objects in the array
            }
        }

        private void CheckforDuplicates()
        {
            for (int index = 0; index < ClassSize - 1; index++)
            {
                int id = Students[index].StudentId;
                for (int innerLoop = index + 1; innerLoop < ClassSize; innerLoop++)
                    if (Students[innerLoop].StudentId == id)
                        throw new Exception(
                                "Duplicate student Ids not allowed in the class list");
            }
        }

        public void AddStudent(Student anotherStudent)
        {
            if (anotherStudent == null)
                throw new Exception("Cannot add null student");
            if (ClassSize >= CLASS_LIMIT)
                throw new ArrayFullException("Class Limit Exceeded - Cannot add student");
            for (int index = 0; index < ClassSize - 1; index++)
            {
                int id = Students[index].StudentId;
                if (anotherStudent.StudentId == id)
                    throw new Exception(
                            "Duplicate student Ids not allowed in the class list");
            }
            Students[ClassSize] = anotherStudent;
            ClassSize++;
        }

        public Student FindStudent(int studentId)
        {
            Student found = null;
            int foundPosition = FindIndexPosition(studentId);
            if (foundPosition >= 0)
                found = Students[foundPosition];
            return found;
        }

        private int FindIndexPosition(int studentId)
        {
            int foundPosition = -1;
            for (int index = 0; index < ClassSize; index++)
                if (Students[index].StudentId == studentId)
                    foundPosition = index;
            return foundPosition;
        }

        public Student RemoveStudent(int studentId)
        {
            Student found = null;
            int foundPosition = FindIndexPosition(studentId);
            if (foundPosition >= 0)
            {
                found = Students[foundPosition];
                Students[foundPosition] = Students[ClassSize - 1];
                ClassSize--;
            }
            return found;
        }
    }
}