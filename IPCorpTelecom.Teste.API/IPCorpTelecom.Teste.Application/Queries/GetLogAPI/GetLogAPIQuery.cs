using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IPCorpTelecom.Teste.Domain.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace IPCorpTelecom.Teste.Application.Queries.GetLogAPI
{
    public class GetLogAPIQuery : IGetLogAPIQuery
    {
        readonly string apiToken = "http://integracao.epbx.com.br:5050/Service/oauth2/Token";
        readonly string apiGetLog = "http://integracao.epbx.com.br/Service/api/LogSistema";

        public async Task<IList<Log>> GetLogAPI()
        {
            IList<Log> Json(string text)
            {
                return JsonConvert.DeserializeObject<IList<Log>>(text);
            }

            Dictionary<string, string> tokenDetails = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiToken);

            var login = new Dictionary<string, string> { { "grant_type", "password" }, { "username", "teste" }, { "password", "teste" }, };
            var response = client.PostAsync("Token", new FormUrlEncodedContent(login)).Result;
            if (response.IsSuccessStatusCode)
            {
                tokenDetails = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);
                if (tokenDetails != null && tokenDetails.Any())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenDetails.FirstOrDefault().Value);
                    var result = await client.GetAsync(apiGetLog + $@"?$filter=Data ge {DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}");
                    var content = result.Content;
                    var text = await content.ReadAsStringAsync();

                    return Json(text);
                }
            }
            return null;
        }
    }
}
