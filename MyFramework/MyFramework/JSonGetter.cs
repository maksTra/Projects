using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyFramework
{
    public class JSonGetter
    {
        private static HttpResponseMessage SendBasicSearchRequest(string request)
        {
            HttpResponseMessage response;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://platformservices.azure-api.net");
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var requestUri = "/search/generic";
                response = client.PostAsync(requestUri, content).Result;
            }
            return response;
        }

        private static string GetResponseContent(HttpResponseMessage response)
        {
            string result;
            result = response.Content.ReadAsStringAsync().Result;
            return result;
        }

        public static List<JsonResult> GetSearchResults(string request)
        {
            HttpResponseMessage response = SendBasicSearchRequest(request);
            var json = JObject.Parse(GetResponseContent(response));
            var jsonResults = JsonConvert.DeserializeObject<JsonResult[]>(json["Results"].ToString()).ToList();
            jsonResults = jsonResults.Where(x => !x.Id.Contains("900000000")).Take(20).ToList();
            return jsonResults;
        }
    }
}
