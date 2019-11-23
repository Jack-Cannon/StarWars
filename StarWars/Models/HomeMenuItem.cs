using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Models
{
    public enum MenuItemType
    {
        Browse,
        About, 
        Starships,
        Planets

    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
