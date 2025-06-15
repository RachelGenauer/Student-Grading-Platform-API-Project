namespace StudentsMarksProject.Configuration1
{
    public class PercentageOfMarks
    {
       public Dictionary<int, int> percentageOfMarks { get; set; }= new();
        public PercentageOfMarks(Dictionary<int, int> percentageOfMarks) { 
        this.percentageOfMarks = percentageOfMarks;
        }
        public PercentageOfMarks()
        {
            percentageOfMarks= new();
        }

    }
}
