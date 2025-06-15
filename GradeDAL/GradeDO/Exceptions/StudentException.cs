using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO.Exceptions
{
    public class StudentNotExsistException : Exception
    {
        public int StatusCode1 { get; }

        public StudentNotExsistException(string StudentId) : base($"The student with Id {StudentId} not exsist")
        {
            StatusCode1 = 999;
        }

    }
    public class StudentAlradyExsistException : Exception
    {
        public int StatusCode2 { get; }
        public StudentAlradyExsistException(string StudentId) : base($"The student with Id {StudentId} aleady exsist")
        {
            StatusCode2 = 888;
        }

    }
    public class GradeNotExsistException : Exception
    {
        public int StatusCode3 { get; }
        public GradeNotExsistException(int code) : base($"The grade with code {code} does not exist")
        {
            StatusCode3 = 777;
        }
    }

    public class PasswordNotExsistException : Exception
    {
        public int StatusCode4 { get; }
        public PasswordNotExsistException(string password) : base($"The password {password} is incorrect")
        {
            StatusCode4 = 666;
        }
    }
}
