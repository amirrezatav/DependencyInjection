namespace DependencyInjection
{
    public class StudentInfo
    {
        public string Name { get; private set; }
        public IDictionary<string, decimal> _scores { get; set; }
        public StudentInfo(string name) 
        {
            Name = name;
            _scores = new Dictionary<string, decimal>();
        }
        public void SetScore(string item, decimal score) => _scores.Add(item, score);
        public decimal GetScore(string item) => _scores[item];
        public decimal GetTotal(IDictionary<string, decimal> weights)
        {
            decimal total = 0;
            foreach (var item in weights.Keys)
                total += _scores[item] * weights[item];
            return total;
        }
        public override string ToString()
        {
            string res = $"Name = {Name} \nScores : \n";
            foreach (var item in _scores.Keys)
                res += $"{item} : {_scores[item]} \n";
            return res;
        }
    }
}
