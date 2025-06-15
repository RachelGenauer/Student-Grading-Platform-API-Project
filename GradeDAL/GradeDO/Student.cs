using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public class Student
    {
        public string ID {  get; set; }
        public string Name { get; set; }
        public string  Password { get; set; }
        public List<Grade> ExeList { get; set; }
        public Grade TestGrade { get; set; }

        public Student()
        {
            ExeList = new List<Grade>();
        }
        public double GradeAverage()
        {
            return ExeList.Average(grade => grade.GradeNumber);
        }
        public override string ToString()
        {
            string s = $"ID: {ID}, Name: {Name}\n";
            foreach (Grade g in ExeList)
            {
                if (g != null)
                    s += $"   {g.ToString()}\n";
            }
            return s;
        }


    }
}
