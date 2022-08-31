using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Contracts.Utils
{
    public class EnviromentVariables
    {
        private async static Task<dynamic> GetDynamicFile()
        {
            string file = "appsettings.json";
            #if (DEBUG)
            file = "appsettings.Development.json";
            #endif
            string text = await System.IO.File.ReadAllTextAsync(file);
            dynamic result = JsonConvert.DeserializeObject<dynamic>(text);
            return result;

        }

        public async static Task<string> GetEncryptKey()
        {
            var json = await GetDynamicFile();
            return json.Settings.EncryptKey;
        }

        public async static Task<string> GetBaseUrl()
        {
            var json = await GetDynamicFile();
            return json.Settings.BaseUrl;
        }

        public async static Task<string> GetBaseStaticFilesUrl()
        {
            var json = await GetDynamicFile();
            return $"{json.Settings.BaseUrl}/{json.Settings.staticFilesUri}";
        }
    }
}
