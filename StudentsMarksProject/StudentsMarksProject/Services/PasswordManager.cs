using GradeDO;
using GradeDO.Exceptions;
using Microsoft.Extensions.Options;
using StudentsMarksProject.Configuration1;

namespace StudentsMarksProject.Services
{
    public class PasswordManager:IPasswordManager
    {
        TeachersDetails _TeachersDetails;
        IStudents _students;
        public PasswordManager(IOptions<TeachersDetails> teacher, IStudents students)
        {
            _TeachersDetails = teacher.Value;
            _students = students;
        }
        public bool CheackPasswordMarnager(string password,string id) {
            if (id.Equals(_TeachersDetails.teachersName)) {
                if (password.Equals(_TeachersDetails.teachersPassword))
                {
                    return true;
                }
                return false;
            }
            else { Student student = _students.StudentsList.Students.FirstOrDefault(student => student.ID.Equals(id));
                if (student == null) {
                    throw new StudentNotExsistException(id);
                }
                if (student.Password.Equals(password))
                {
                    return true;
                }
                return false;
            }
        }
    }
}
