using System;
using System.Collections.Generic;
using StarWars.ViewModels;
using Xamarin.Forms;

namespace StarWars.Views
{
    public partial class PeoplePage : ContentPage
    {
        PeopleViewModel viewModel;

        public PeoplePage()
        {
            InitializeComponent();

            viewModel = new PeopleViewModel();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.People.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}


