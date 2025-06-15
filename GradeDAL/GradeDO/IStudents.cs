using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public interface IStudents
    {
        public DataSource StudentsList { get; set; }
        public void AddStudent(Student student);
        public void RemoveStudent(string  student);
        public void AddGradeToStudent(string StudentId, Grade grade);
        public void UpdateDetails(string StudentId, string name = null, string password = null);
        public string ShowAllStudentsDetails();
        public string ShowStudentsDetails(string StudentId);
        public void AddGradesToStudents(List<Grade> grades, List<Student> students);
        public void UpdateGrade(string StudentId, Grade grade);

        public Grade ShowGrade(string studentId, int exeNumber);
    }
}