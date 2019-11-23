using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWars.Models;
using Xamarin.Essentials;

namespace StarWars.Services
{
    public class StarshipsDataStore : IReadOnlyDataStore<Starship>
    {
        HttpClient client;
        public List<Starship> starships { get; private set; }

        public StarshipsDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.StarWarsBaseUrl}");
            starships = new List<Starship>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<Starship> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"starships/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Starship>(json));
            }

            return null;
        }

        public async Task<IEnumerable<Starship>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"starships");
                var response = await Task.Run(() => JsonConvert.DeserializeObject<APIResults<Starship>>(json));

                starships = response.results;
            }

            return starships;
        }
    }
}
