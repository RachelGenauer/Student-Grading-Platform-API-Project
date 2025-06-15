using GradeDO;
using System.ComponentModel.DataAnnotations;

namespace StudentsMarksProject.Modules
{
    public class M_Grade
    {
        [Required]
        [Range(0,100)]
        public int ExeNumber { get; set; }
        [MaxLength(8)]
        [MinLength(2)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int GradeNumber { get; set; }
        public string Comment { get; set; }
        public Grade Convert()
        {
            return new Grade() { ExeNumber = ExeNumber,Name=Name, Date=Date, GradeNumber =GradeNumber , Comment =Comment };
        }
    }
}
