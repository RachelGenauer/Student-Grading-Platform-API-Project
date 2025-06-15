using DAL.Models;
using GradeDO;
using Microsoft.AspNetCore.Mvc;

namespace DAL.Controllers
{
    public class GradeController : Controller
    {
        public GradeController(IStudent student)
        {
                
        }
        [HttpPost]
        public void AddGrade(string Id, M_Grade m_Grade)
        {
            student.AddGradeToStudent(Id, m_Grade.Convert());
        }
       
    }
}
