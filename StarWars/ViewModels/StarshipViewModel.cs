using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using StarWars.Models;
using StarWars.Services;
using Xamarin.Forms;

namespace StarWars.ViewModels
{
    public class StarshipViewModel : BaseViewModel
    {
        public ObservableCollection<Starship> Starships { get; set; }
        public Command LoadItemsCommand { get; set; }
        public StarshipsDataStore DataStore => new StarshipsDataStore(); //DependencyService.Get<IReadOnlyDataStore<Person>>();

        public StarshipViewModel()
        {
            Title = "Starships";
            Starships = new ObservableCollection<Starship>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Starships.Clear();
                var starships = await DataStore.GetItemsAsync(true);
                foreach (var starship in starships)
                {
                    Starships.Add(starship);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
