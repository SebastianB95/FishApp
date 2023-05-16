using static FishApp.FishBase;

namespace FishApp
{
    public interface IFish
    {
        string Name { get; }

        string Weight { get; }

        string Time { get; }

        public void AddGrade(float grade);

        public void AddGrade(int grade);

        public void AddGrade(string grade);

        public event GradeAddedDelegate GradeAdded;

        Statistics GetStatistics();

        public void Statistic();

    }   
}
