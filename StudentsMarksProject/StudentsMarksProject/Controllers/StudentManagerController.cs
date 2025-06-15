using GradeDO;
using Microsoft.AspNetCore.Mvc;
using StudentsMarksProject.Modules;
using StudentsMarksProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentsMarksProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagerController : ControllerBase
    {
        IStudents students;
        public StudentManagerController(IStudents _students)
        {
            students = _students;
        }
       
        [HttpGet("{studentID}")]
        public string GetStudent(string studentID)
        {
            return students.ShowStudentsDetails(studentID);
        }

        
        [HttpGet("All student details")]
        public string GetAllStudentDetails()
        {
            return students.ShowAllStudentsDetails();
        }
                
        [HttpPost]
        public void Post([FromBody][Bind("Name", "ID")] M_Students _student)
        {
            Student student = _student.Convert();
            students.AddStudent(student);

        }
                
        [HttpPut("update Details")]
        public void Put([Bind][FromBody] string studentId, string NewName = null, string NewPassword = null)
        {
            students.UpdateDetails(studentId, NewName, NewPassword);
        }

     
        [HttpDelete("{studentId}")]
        public void Delete([Bind][FromBody] string studentId)
        {

            students.RemoveStudent(studentId);
        }
    }
}
