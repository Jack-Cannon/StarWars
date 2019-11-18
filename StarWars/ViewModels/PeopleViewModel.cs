using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using StarWars.Models;
using StarWars.Services;
using Xamarin.Forms;

namespace StarWars.ViewModels
{
    public class PeopleViewModel: BaseViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public Command LoadItemsCommand { get; set; }
        public PeopleDataStore DataStore => new PeopleDataStore(); //DependencyService.Get<IReadOnlyDataStore<Person>>();

        public PeopleViewModel()
        {
            Title = "People";
            People = new ObservableCollection<Person>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                People.Clear();
                var people = await DataStore.GetItemsAsync(true);
                foreach (var person in people)
                {
                    People.Add(person);
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
