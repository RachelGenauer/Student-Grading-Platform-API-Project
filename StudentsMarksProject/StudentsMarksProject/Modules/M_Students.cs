using GradeDO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace StudentsMarksProject.Modules
{
    public class M_Students {
        [StringLength(9)]
        [Required]
        public string ID { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Grade> ExeList { get; set; }
        public Grade TestGrade { get; set; }
        public Student Convert()
        {
            return new Student() { ID= ID, Name=Name, Password=Password, ExeList=ExeList, TestGrade =TestGrade };
        }
    }
}
