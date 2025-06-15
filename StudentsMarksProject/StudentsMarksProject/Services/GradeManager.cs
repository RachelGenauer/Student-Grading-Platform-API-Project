using GradeDO;
using GradeDO.Exceptions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StudentsMarksProject.Configuration1;
using StudentsMarksProject.Modules;
using System;
using System.Diagnostics;

namespace StudentsMarksProject.Services
{
    public class GradeManager:IGradeManager
    { 
        IStudents _students;
        PercentageOfMarks _percentageOfMarks;
        IConfiguration _configuration;
        public GradeManager(IConfiguration configuration, IOptions<PercentageOfMarks> percentageOfmarks,IStudents students)
        {
            _students = students;
            _configuration = configuration;
            _percentageOfMarks = percentageOfmarks.Value;
        }
        public double FinalMark(string studentId) {
            Student student = _students.StudentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            double sum = 0;
            if (student == null) 
            throw new StudentNotExsistException(studentId);
            foreach (var mark in _percentageOfMarks.percentageOfMarks)
            {
                Grade grade = student.ExeList.FirstOrDefault(exe => exe.ExeNumber == mark.Key);
                if (grade != null)
                    sum += ((double)(mark.Value) / 100 * (grade.GradeNumber));
                  
            }
            sum += student.TestGrade.GradeNumber * _percentageOfMarks.percentageOfMarks[99] / 100;
            return sum;
        }
        public string[] AllStudentsFinalMarks() {
            string[] studentsMarks = new string[_students.StudentsList.Students.Count];
            int i = 0;
            foreach (var s in _students.StudentsList.Students)
            {
                studentsMarks[i]=$"{s.Name},Your mark is:{FinalMark(s.ID)}";
                i++;
            }
            return studentsMarks;
            }
        public double AvarageOfMark(int exeCode)
        {
            double avarageOfMarks = 0;
            foreach (var student in _students.StudentsList.Students)
            {
                Grade grade = student.ExeList.FirstOrDefault(exe => exe.ExeNumber == exeCode);
                avarageOfMarks += grade.GradeNumber;
              
            }
            return avarageOfMarks = avarageOfMarks / _students.StudentsList.Students.Count;
        }
        public void AddGradesToStudent(List<string> studentsIds, List<int> grades, int exeCode, string name)
        {
            for (int i = 0; i < studentsIds.Count; i++)
            {
                Student student = _students.StudentsList.Students.FirstOrDefault(stu => stu.ID == studentsIds[i]);
                if (student == null)
                    throw new StudentAlradyExsistException(studentsIds[i]);
                else
                {
                    Grade g = new Grade(exeCode, grades[i], name);
                    student.ExeList.Add(g);
                }

            }
        }
        public List<double> AllStudentsGrades(int exeNum)
        {
            List<double> list = new List<double>();
            if (exeNum == 99)
            {
                foreach (var student in _students.StudentsList.Students)
                {
                    list.Add(student.TestGrade.GradeNumber);
                }
            }
            else
            {
                foreach (Student s in _students.StudentsList.Students)
                {
                    Grade grade = s.ExeList.FirstOrDefault(g => g.ExeNumber == exeNum);
                    if (grade == null)
                        throw new GradeNotExsistException(exeNum);
                    list.Add(grade.GradeNumber);
                }
            }
                return list;
            }
        
        public Dictionary<int, List<double>> getGradesStudents()
        {
           
            Dictionary<int, List<double>> d = new Dictionary<int, List<double>>();
            foreach(var mark in _percentageOfMarks.percentageOfMarks)
            {
                 d.Add(mark.Key, AllStudentsGrades(mark.Key));
            }
            return d;
        }
        public Grade ReturnTheLastGrade(string studentId)
        {   
            Student student = _students.StudentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            if(student == null)
                throw new StudentNotExsistException(studentId);
           Grade lastGrade = student.ExeList.Last();
            return lastGrade;
        }
        public Grade ReturnASpesificGrade(string studentId,int execode)
        {
            Student student = _students.StudentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            if (student == null)
                throw new StudentNotExsistException(studentId);
            Grade grade = student.ExeList.FirstOrDefault(grade => grade.ExeNumber == execode);
            if (grade == null)
                throw new GradeNotExsistException(execode);
            return grade;
        }
        public Grade ReturnTestGrade(string studentId) {
            Student student = _students.StudentsList.Students.FirstOrDefault(stu => stu.ID == studentId);
            if (student == null)
                throw new StudentNotExsistException(studentId);
            Grade grade = student.TestGrade;
            if (grade == null)
                throw new GradeNotExsistException(2);
            return grade;
        }

    }
}
