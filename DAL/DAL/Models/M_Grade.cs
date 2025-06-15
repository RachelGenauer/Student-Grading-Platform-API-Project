using GradeDO;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAL.Models
{
    public class M_Grade
    {
        [BindRequired]
        public int ExeNumber { get; set; }

        public Grade Convert()
        {
            return new Grade() { ExeNumber = ExeNumber };
        }
    }
}
