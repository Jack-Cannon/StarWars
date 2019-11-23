using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using StarWars.Models;
using StarWars.Services;
using Xamarin.Forms;

namespace StarWars.ViewModels
{
    public class PlanetsViewModel : BaseViewModel
    {
        public ObservableCollection<Planet> Planets { get; set; }
        public Command LoadItemsCommand { get; set; }
        public PlanetsDataStore DataStore => new PlanetsDataStore(); //DependencyService.Get<IReadOnlyDataStore<Person>>();

        public PlanetsViewModel()
        {
            Title = "Planets";
            Planets = new ObservableCollection<Planet>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Planets.Clear();
                var planets = await DataStore.GetItemsAsync(true);
                foreach (var planet in planets)
                {
                    Planets.Add(planet);
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
