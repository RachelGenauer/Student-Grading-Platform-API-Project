using GradeDO;
using GradeDO.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentsMarksProject.Modules;
using StudentsMarksProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsMarksProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeManagerController : ControllerBase
    {
        IGradeManager _GradeMeneger;
        IStudents _Students;

        IConfiguration _configuration;
        ILogger<GradeManagerController> _logger;

        public GradeManagerController(IGradeManager gradeMeneger, ILogger<GradeManagerController> logger, IStudents students)
        {
            _GradeMeneger = gradeMeneger;
            _logger = logger;
            _Students = students;
        }

        [HttpGet]
        public List<double> Get([FromQuery] int exe)
        {
            return _GradeMeneger.AllStudentsGrades(exe);
        }

        [HttpPost]
        public void UpDateExe([FromBody] M_List lists, [FromQuery] int exe, [FromQuery] string name)
        {
            _GradeMeneger.AddGradesToStudent(lists.StudentsIds, lists.Grades, exe, name);
        }
        [HttpPut]
        public IActionResult AddGrade([FromQuery] string StudentId, [FromQuery] M_Grade grade)
        {
            _Students.UpdateGrade(StudentId, grade.Convert());
            if (grade.Convert() == null)
            {
                return BadRequest();
            }
            else
            {
                _logger.LogInformation($"the student with id:{StudentId} added succesfully;");
                return Ok();
            }
        }

        [HttpGet("SHOWGRADES")]
        public  string[] GetAllStudentFinalMarks()
        {
            return _GradeMeneger.AllStudentsFinalMarks();
        }
        [HttpGet("SHOW_ALL_GRADES_AND_ALL_EXE")]
        public Dictionary<int,List<double>> GetAllGradesAndExercises()
        {
            return _GradeMeneger.getGradesStudents();
        }
    }
}
