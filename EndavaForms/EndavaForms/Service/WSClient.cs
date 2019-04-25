using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace EndavaForms.Service
{
    public class WSClient
    {
        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
