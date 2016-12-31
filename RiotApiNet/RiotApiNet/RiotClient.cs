using RiotApiNet.Dto.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RiotApiNet.Enums;
using Newtonsoft.Json;
using RiotApiNet.Dto.ChampionMastery;

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

        public async Task<ChampionMasteryDto> GetChampionMastery(Location SummLocation,Region SummRegion, long PlayerId, long ChampionId)
        {
            ChampionMasteryDto Mastery = null;
            using (HttpClient http = new HttpClient())
            {
                string uri = "https://" + SummRegion.ToString().ToLower() + ".api.pvp.net/championmastery/location/" + SummLocation.ToString().ToLower() +"/player/" + PlayerId + "/champion/" + ChampionId + "?api_key=" + ApiKey;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                Mastery = JsonConvert.DeserializeObject<ChampionMasteryDto>(jsonString);
            }
            return Mastery;
        }
        public async Task<List<ChampionMasteryDto>> GetChampionMasteryByPlayerId(Location SummLocation, Region SummRegion, long PlayerId)
        {
            List<ChampionMasteryDto> Masteries = null;
            using (HttpClient http = new HttpClient())
            {
                string uri = "https://" + SummRegion.ToString().ToLower() + ".api.pvp.net/championmastery/location/" + SummLocation.ToString().ToLower() + "/player/" + PlayerId + "/champion/?api_key=" + ApiKey;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                Masteries = JsonConvert.DeserializeObject<List<ChampionMasteryDto>>(jsonString);
            }
            return Masteries;
        }

        public async Task<Int32> GetMasteryTotalByPlayerId(Location SummLocation, Region SummRegion, long PlayerId)
        {
            int MasteryTotal = 0;
            using (HttpClient http = new HttpClient())
            {
                string uri = "https://" + SummRegion.ToString().ToLower() + ".api.pvp.net/championmastery/location/" + SummLocation.ToString().ToLower() + "/player/" + PlayerId + "/score/?api_key=" + ApiKey;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                MasteryTotal = JsonConvert.DeserializeObject<Int32>(jsonString);
            }
            return MasteryTotal;
        }
        public async Task<List<ChampionMasteryDto>> GetTopChampionMasteryByPlayerId(Location SummLocation, Region SummRegion, long PlayerId, int Count = 3)
        {
            List<ChampionMasteryDto> Masteries = null;
            using (HttpClient http = new HttpClient())
            {
                string uri = "https://" + SummRegion.ToString().ToLower() + ".api.pvp.net/championmastery/location/" + SummLocation.ToString().ToLower() + "/player/" + PlayerId + "/topchampions?count=" + Count + "&api_key=" + ApiKey;
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                var response = await http.GetAsync(uri);
                var jsonString = await response.Content.ReadAsStringAsync();
                Masteries = JsonConvert.DeserializeObject<List<ChampionMasteryDto>>(jsonString);
            }
            return Masteries;
        }
    }
}
