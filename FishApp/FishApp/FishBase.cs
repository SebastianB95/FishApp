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
        public abstract void AddGrade(string grade);
        public abstract void AddGrade(int grade);
        public abstract Statistics GetStatistics();
    }
}
