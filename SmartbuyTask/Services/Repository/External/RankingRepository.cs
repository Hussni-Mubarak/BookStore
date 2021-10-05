using BookStore.Models;
using BookStore.Services.Interface.External;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services.Repository.External
{
    public class RankingRepository : IRanking
    {
        public async Task<League> GetRanking(long id)
        {

            var client = new RestClient($"http://api.football-data.org/v1/competitions/{id}/leagueTable");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                //Get the league caption
                var leagueCaption = content["leagueCaption"].Value<string>();

                //Get the standings for the league.
                var rankings = content.SelectTokens("standing[*]")
                    .Select(team => new Standing
                    {
                        TeamName = (string)team["teamName"],
                        Position = (int)team["position"]
                    })
                    .ToList();

                //return the model to my caller.
                return new League
                {
                    LeagueCaption = leagueCaption,
                    Standings = rankings
                };
            }

            //TODO: log error, throw exception or do other stuffs for failed requests here.
            Console.WriteLine(response.Content);

            return null;
        }
    }
}
   