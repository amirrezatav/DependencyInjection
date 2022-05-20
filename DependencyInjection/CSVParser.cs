using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace DependencyInjection
{
    public class CSVParser : IGradeBookParser
    {
        string _filename;
        public CSVParser(string filename) => _filename = filename;
        public IEnumerable<StudentInfo> Parse()
        {
            ICollection<StudentInfo> result = new List<StudentInfo>();
            using (var streamRdr = new StreamReader(_filename))
            {
                var csvReader = new CsvReader(streamRdr, CultureInfo.CurrentCulture);
                if(csvReader.Read())
                {
                    var header = csvReader.Parser.Record;
                    while (csvReader.Read())
                    {
                        var recored = csvReader.Parser.Record;
                        StudentInfo si = new StudentInfo(recored[0]);
                        for (int i = 1; i< recored.Length; i++)
                            si.SetScore(header[i], (decimal)Convert.ToDouble(recored[i]));
                        result.Add(si);
                    }
                }
                
            }
            return result;
        }
    }
}
