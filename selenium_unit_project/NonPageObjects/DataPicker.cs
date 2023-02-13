using Microsoft.VisualBasic.FileIO;
using System.Text;
namespace AppGreatSelenium.NonPageObjects
{
    internal class DataPicker
    {
        public static string GenerateRandomString(int numberOfCharacters, String allowedCharacters)
        {
            const int from = 0;
            int to = allowedCharacters.Length;
            Random r = new Random();
            StringBuilder qs = new StringBuilder();
            for (int i = 0; i < numberOfCharacters; i++)
            {
                qs.Append(allowedCharacters.Substring(r.Next(from, to), 1));
            }
            return qs.ToString();
        }
        public static Dictionary<String, Object> GetRandomObject(String fileToGetObjectFrom)
        {
            List<Dictionary<String, Object>> dataSet = new List<Dictionary<String, Object>>();
            using (TextFieldParser parser = new TextFieldParser(@"..\..\..\TestData\" + fileToGetObjectFrom + ".csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] fields = parser.ReadFields();
                while (!parser.EndOfData)
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    string[] linRow = parser.ReadFields();
                    int i = 0;
                    foreach (string field in linRow)
                    {
                        row.Add(fields[i], field);
                        i++;
                    }
                    dataSet.Add(row);
                }
            }

            Random rnd = new Random();
            return dataSet.ElementAt(rnd.Next(0, dataSet.Count));
        }
    }
}
