using GradeDO;

namespace StudentsMarksProject.Services
{
    public interface IGradeManager
    {
        public double FinalMark(string studentId);
        public string[] AllStudentsFinalMarks();
        public double AvarageOfMark(int exeCode);
        public void AddGradesToStudent(List<string> studentsIds, List<int> grades, int exeCode, string name);
        public List<double> AllStudentsGrades(int exeNum);
        public Dictionary<int, List<double>> getGradesStudents();
        public Grade ReturnTheLastGrade(string studentId);
        public Grade ReturnASpesificGrade(string studentId, int execode);
        public Grade ReturnTestGrade(string studentId);
    }
}
