using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Utils
{
    public static class JsonHelper
    {
        public static string GetJonStringText(string json)
        {
            {
                if (String.IsNullOrEmpty(json))
                    return "";

                var propsValues = json.Replace("{", "").Replace("}", "").Split(",");
                StringBuilder answers = new StringBuilder();
                foreach (var propValue in propsValues)
                {
                    var propValueParts = propValue.Split(":");
                    string prop = "", value = "";

                    if (propValueParts.Length > 1)
                    {
                        prop = $"{propValueParts.FirstOrDefault()} : ";
                        value = propValueParts.LastOrDefault();
                        if (value.Contains("["))
                            value = $"\n - {value.Replace("[", "").Replace("]", "")}";
                    }
                    else
                    {
                        value = propValueParts[0];
                        value = $" - {value.Replace("]", "")}";
                    }

                    if (value == "\"\"" || value == "[]" || value == "")
                        continue;

                    answers.Append($"{prop.Replace("\"", "").Replace("_", " ")}{value.Replace("\"", "")}\n");
                }
                return answers.ToString();
            }
        }
    }
}
