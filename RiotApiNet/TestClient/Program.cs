using RiotApiNet.Dto.Champion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        static RiotApiNet.RiotClient Client;
        static void Main(string[] args)
        {
            Client = new RiotApiNet.RiotClient("3538eab2-cfdc-4ccc-b0ce-869643d826cc");
            GetChampionById();
            Console.ReadLine();            
        }

        private static async Task<ChampionDto> GetChampionById()
        {
            ChampionDto TestChampion = await Client.GetChampionById(RiotApiNet.Enums.Region.EUW, 1);
            Console.WriteLine(TestChampion);
            return TestChampion;
        }
    }
}
