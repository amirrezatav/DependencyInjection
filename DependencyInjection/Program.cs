

using DependencyInjection;
using Newtonsoft.Json;
using System.Reflection;

string config = File.ReadAllText("config.json");

config deserialized = JsonConvert.DeserializeObject<config>(config);

Type magicType = Type.GetType(deserialized.ParserName);
ConstructorInfo magicConstructor = magicType.GetConstructor(new[] { typeof(string) });
IGradeBookParser parser = (IGradeBookParser)(magicConstructor.Invoke(new object[] { deserialized.filename }));

GradeBook gradeBook = new GradeBook(parser);

foreach (var item in gradeBook.Students)
{
    Console.WriteLine(gradeBook.GetItem(item.Name).ToString());
}
Dictionary<string, decimal> weights = new Dictionary<string, decimal>();
weights.Add("Math", 1);
weights.Add("data structure", 1);
weights.Add("electrical circuit", 1);
weights.Add("Electronic", 1);
Console.WriteLine($"Precent Passed: {gradeBook.PrecentPassed(weights)}");