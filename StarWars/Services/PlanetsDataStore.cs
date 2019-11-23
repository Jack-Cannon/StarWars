using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWars.Models;
using Xamarin.Essentials;
namespace StarWars.Services
{
    public class PlanetsDataStore : IReadOnlyDataStore<Planet>
    {
        HttpClient client;
        public List<Planet> planets { get; private set; }

        public PlanetsDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.StarWarsBaseUrl}");
            planets = new List<Planet>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<Planet> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"planets/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Planet>(json));
            }

            return null;
        }

        public async Task<IEnumerable<Planet>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"planets");
                var response = await Task.Run(() => JsonConvert.DeserializeObject<APIResults<Planet>>(json));

                planets = response.results;
            }

            return planets;
        }
    }
}
