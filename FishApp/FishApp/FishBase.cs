namespace FishApp
{
    public abstract class FishBase : IFish
    {
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public abstract event GradeAddedDelegate GradeAdded;

        public FishBase(string name, string weight, string time)
        {
            this.Name = name;
            this.Weight = weight;
            this.Time = time;
        }

        public string Name { get; private set; }

        public string Weight { get; private set; }

        public string Time { get; private set; }

        public abstract void AddGrade(float grade);

        public virtual void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                throw new Exception("Niepoprawna forma oceny");
            }
        }
        
        public virtual void AddGrade(int grade)
        {
            this.AddGrade((float)grade);
        }

        public abstract Statistics GetStatistics();

        public void GetAndWriteStatistics()
        {
            var statistic = GetStatistics();
            Console.WriteLine($"Minimalna Ocena Ryby:   {statistic.Min}");
            Console.WriteLine($"Maksymalna Ocena Ryby:   {statistic.Max}");
            Console.WriteLine($"Srednia Ocen Ryby:   {statistic.Average:N2}");
            Console.WriteLine($"Suma Wszystkich Ocen:   {statistic.Sum}/50");

        }
    }
}
