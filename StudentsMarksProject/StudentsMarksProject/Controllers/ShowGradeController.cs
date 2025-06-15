using GradeDO;
using GradeDO.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentsMarksProject.Configuration1;
using StudentsMarksProject.Modules;
using StudentsMarksProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsMarksProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowGradeController : ControllerBase
    {
        IGradeManager _GradeManager;
        IStudents _Students;
        IPasswordManager _PasswordManager;
        ILogger<StudentManagerController> _logger;
        IOptions<PercentageOfMarks> _percentageOfMarks;
        public ShowGradeController(IGradeManager gradeManager, ILogger<StudentManagerController> logger, IStudents students, IPasswordManager passwordManager, IOptions<PercentageOfMarks> present)
        {
            _GradeManager = gradeManager;
            _logger = logger;
            _Students = students;
            _PasswordManager = passwordManager;
        }


        [HttpGet("ReturnLastGrad")]
        public Dictionary<string,double> ReturnLastGrade([FromQuery] string studentId, [FromQuery] string pass)
        {
            Dictionary<string, double> AvarageAndGrade = new();
            if (_PasswordManager.CheackPasswordMarnager(pass,studentId) == true)
            {
                AvarageAndGrade["the latest grade"]=(_GradeManager.ReturnTheLastGrade(studentId).GradeNumber);
                AvarageAndGrade["the avarage is"]=(_GradeManager.AvarageOfMark(_GradeManager.ReturnTheLastGrade(studentId).ExeNumber));
                return AvarageAndGrade;
            }
            throw new PasswordNotExsistException(pass);
        }
        [HttpGet("ReturnSpecificGrade")]
          public Dictionary<string, double> ReturnSpecificGrade([FromQuery] string studentId, [FromQuery] string pass, [FromQuery] int execode)
            {
            Dictionary<string, double> SpesificAvarageAndGrade = new();
                if (_PasswordManager.CheackPasswordMarnager(pass, studentId) == true)
                {
                SpesificAvarageAndGrade[$"the grade of {execode} is"] = (_GradeManager.ReturnASpesificGrade(studentId,execode).GradeNumber);
                SpesificAvarageAndGrade["the avarage is"] = (_GradeManager.AvarageOfMark(execode));
                    return SpesificAvarageAndGrade;
                }
                throw new PasswordNotExsistException(pass);
            }
        [HttpGet("ReturnTestGrade")]
        public double ReturnGradeTets([FromQuery] string studentId, [FromQuery] string pass)
        {
            if (_PasswordManager.CheackPasswordMarnager(pass, studentId) == true)
            {
              
             double TestGrade=_GradeManager.ReturnTestGrade(studentId).GradeNumber;
                  return TestGrade;
            }
            throw new PasswordNotExsistException(pass);
        }
        [HttpGet("ReturnFinalGrade")]
        public double ReturnFinalGrade([FromQuery] string studentId, [FromQuery] string pass)
        {
            if (_PasswordManager.CheackPasswordMarnager(pass, studentId) == true)
            {

                double FinalGrade = _GradeManager.FinalMark(studentId);
                return FinalGrade;
            }
            throw new PasswordNotExsistException(pass);
        }
    }
}
