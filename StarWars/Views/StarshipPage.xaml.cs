using System;
using System.Collections.Generic;
using System.Linq;
using StarWars.ViewModels;
using Xamarin.Forms;

namespace StarWars.Views
{
    public partial class StarshipPage : ContentPage
    {
        StarshipViewModel viewModel;

        public StarshipPage()
        {
            InitializeComponent();

            viewModel = new StarshipViewModel();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Starships.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}