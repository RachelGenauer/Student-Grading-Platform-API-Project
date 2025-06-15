using GradeDO.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public class Students : IStudents
    {
       public DataSource StudentsList{ get; set; } = new DataSource();

        public Students()
        {
            StudentsList.Initialize();
        }

        public void AddStudent(Student student)
        {
            if (StudentsList.Students.Any(stu => stu.ID == student.ID))
                throw new StudentAlradyExsistException(student.ID);
            student.Password = student.ID;
            StudentsList.Students.Add(student);
            
        }
        public void RemoveStudent(string studentId)
        {
            Student student = StudentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            if (student == null)
                throw new StudentNotExsistException(studentId);
            else
                StudentsList.Students.Remove(student);
        }

        public void AddGradeToStudent(string StudentId, Grade grade)
        {
            Student student = StudentsList.Students.FirstOrDefault(stu => stu.ID==StudentId);
            if(student == null) 
                throw new StudentNotExsistException(StudentId);
            grade.Date = DateTime.Today;
            student.ExeList.Add(grade);
        }
        public void UpdateDetails(string studentId, string name = null, string password = null)
        {

            Student student = StudentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            if (student == null)
                throw new StudentNotExsistException(studentId);
            else
            {
                if (name != null)
                    student.Name = name;
                if (password != null)
                    student.Password = password;
            }
        }
        public string ShowAllStudentsDetails()
        {
            string s = "Students Details:\n";
            foreach (Student student in StudentsList.Students)
                if (student != null)
                    s += $"{student.ToString()} \n";
            return s;
        }
        public string ShowStudentsDetails(string StudentId)
        {
            Student student = StudentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if (student == null)
                throw new StudentNotExsistException(StudentId);
            return student.ToString();

        }
        public void AddGradesToStudents(List <Grade> grades,List <Student> students)
        {
            int i = 0;
            foreach (Grade grade in grades)
            {
                AddGradeToStudent(students[i].ID,grade);
                    i++;
            }
        }
        public void UpdateGrade(string StudentId,Grade grade)
        {
            Student student = StudentsList.Students.FirstOrDefault(stu => stu.ID == StudentId);
            if (student == null)
                throw new StudentNotExsistException(StudentId);
            Grade grade1 = student.ExeList.FirstOrDefault(grade => grade.ExeNumber== grade.ExeNumber);
            if (grade1!=null)
                 student.ExeList.Remove(grade1);
            student.ExeList.Add(grade);
        }
        public Grade ShowGrade(string studentId,int exeNumber )
        {
            Student student = StudentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            if (student == null)
                throw new StudentNotExsistException(studentId);
            Grade grade = student.ExeList.FirstOrDefault(grade => grade.ExeNumber== grade.ExeNumber);
           return grade;   
        }
    }
}
