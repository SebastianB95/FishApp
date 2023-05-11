namespace FishApp
{
    public class FishInMemory : FishBase
    {
        private List<float> grades = new List<float>();
        public override event GradeAddedDelegate GradeAdded;
        public FishInMemory(string name, string weight, string time)
            : base(name, weight, time)
        {

        }
        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 10)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Za Duza ocena");
            }
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                throw new Exception("Nie poprawna ocena");
            }
        }
        public override void AddGrade(int grade)
        {
            this.AddGrade((float)grade);
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}
