using System;
using System.Collections.Generic;
using System.Linq;
using StarWars.ViewModels;
using Xamarin.Forms;

namespace StarWars.Views
{
    public partial class PlanetsPage : ContentPage
    {
        PlanetsViewModel viewModel;

        public PlanetsPage()
        {
            InitializeComponent();

            viewModel = new PlanetsViewModel();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Planets.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}