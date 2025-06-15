using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeDO
{
    public class Grade
    {
        public int ExeNumber { get; set; }//1 ,2 99= for the test
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double GradeNumber { get; set; }
        public string Comment { get; set; }
        public Grade(int exeNun, int exeGrade, string name)
        {
            ExeNumber = exeNun;
            Name = exeGrade.ToString();
            Date = DateTime.Now;
            GradeNumber = exeGrade;
            Name = "name";
        }
        public Grade() { }
        public override string ToString()
        {
            return $"{Name}: ExeNumber:{ExeNumber} ,Mark: {GradeNumber},Comment: {Comment}, Date: {Date}";
        }

    }
}
