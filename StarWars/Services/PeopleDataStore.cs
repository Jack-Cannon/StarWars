using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StarWars.Models;
using Xamarin.Essentials;

namespace StarWars.Services
{
    public class PeopleDataStore: IReadOnlyDataStore<Person>
    {
        HttpClient client;
        public List<Person> people { get; private set; }

        public PeopleDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.StarWarsBaseUrl}"); 
            people = new List<Person>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<Person> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"people/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Person>(json));
            }

            return null;
        }

        public async Task<IEnumerable<Person>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"people");
                var response = await Task.Run(() => JsonConvert.DeserializeObject<APIResults<Person>>(json));

                people = response.results;
            }

            return people;
        }
    }
}
