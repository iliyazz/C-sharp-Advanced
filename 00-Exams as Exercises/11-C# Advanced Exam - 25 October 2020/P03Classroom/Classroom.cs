using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;

        public List<Student> Students { get => students; set => students = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int Count => students.Count;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if (Students.Count < Capacity)
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students.Where(x => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            List<Student> studentsBySubject = new List<Student>();
            studentsBySubject = Students.Where(x => x.Subject == subject).ToList();
            if (studentsBySubject.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            var sb = new StringBuilder();
            sb.Append($"Subject: {subject}{Environment.NewLine}Students:");
           
            foreach (var item in studentsBySubject)
            {
                sb.Append($"{Environment.NewLine}{item.FirstName} {item.LastName}");
            }
            return sb.ToString().TrimEnd();
        }
        public int GetStudentsCount()
        {
            return Students.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student student = Students.Where((x) => x.FirstName == firstName && x.LastName == lastName).FirstOrDefault();
            return student;
        }
    }
}
