namespace StudentsMarksProject.Configuration1
{
    public class TeachersDetails
    {
        public string teachersPassword { get; set; } = null;
        public string teachersName { get; set; } = null;
        public TeachersDetails(string teachersPassword, string teachersName)
        {
            this.teachersPassword = teachersPassword;
            this.teachersName = teachersName;
        }
        public TeachersDetails()
        {
                
        }
    }
}
