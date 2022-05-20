
using Newtonsoft.Json;

namespace DependencyInjection
{
    public class JsonParser : IGradeBookParser
    {
        string _filename;
        public JsonParser(string filename) => _filename = filename;
        public IEnumerable<StudentInfo> Parse()
        {
            List<StudentInfo> result = new List<StudentInfo>();
            var json = File.ReadAllText(_filename);
            var deserialized = JsonConvert.DeserializeObject<List<StudentInfo>>(json);
            if(deserialized != null)
                result.AddRange(deserialized);
            return result;
        }
    }
}
