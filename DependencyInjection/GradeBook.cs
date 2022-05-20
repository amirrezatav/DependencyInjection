
namespace DependencyInjection
{
    public class GradeBook
    {
        public ICollection<StudentInfo> Students { get; private set; }
        public GradeBook(IGradeBookParser gradeBookParser)
        {
            try
            {
                Students = gradeBookParser.Parse().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Environment.Exit(0);
            }
        }
        public StudentInfo GetItem(string name)
        {
            return Students.SingleOrDefault(x=> x.Name.ToLower() == name.ToLower());
        }
        public decimal PrecentPassed(IDictionary<string , decimal> weights)
        {
            int passCount = 0;
            decimal total = weights.Sum(x => x.Value);
            foreach (StudentInfo student in Students)
                passCount += student.GetTotal(weights) / total < 10 ? 0 : 1;
            return (decimal)(passCount * 100.0 / Students.Count);
        }
    }
}
