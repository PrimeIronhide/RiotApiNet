using RiotApiNet.Dto.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RiotApiNet.Enums;
using Newtonsoft.Json;

namespace RiotApiNet
{
    public class RiotClient
    {
        public string ApiKey;
        public RiotClient(string YourApiKey)
        {
            ApiKey = YourApiKey;
        }

        public async Task<ChampionListDto> GetChampionList(Region SummRegion)
        {
            ChampionListDto AllChampions = null;
            using (HttpClient http = new HttpClient())
            {
                string uri = "https://" + SummRegion.ToString().ToLower() + ".api.pvp.net/api/lol/" + SummRegion.ToString().ToLower() + "/v1.2/champion?api_key=" + ApiKey;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                AllChampions = JsonConvert.DeserializeObject<ChampionListDto>(jsonString);
            }
            return AllChampions;
        }

        public async Task<ChampionDto> GetChampionById(Region SummRegion, long ChampionId)
        {
            ChampionDto Champion = null;
            using (HttpClient http = new HttpClient())
            {
                string uri = "https://" + SummRegion.ToString().ToLower() + ".api.pvp.net/api/lol/" + SummRegion.ToString().ToLower() + "/v1.2/champion/" + ChampionId + "?api_key=" + ApiKey;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                Champion = JsonConvert.DeserializeObject<ChampionDto>(jsonString);
            }
            return Champion;
        }
    }
}
