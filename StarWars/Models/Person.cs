using System;
using System.Collections.Generic;

namespace StarWars.Models
{
    public class Person
    {
        public Person()
        {
        }

        public string id { get; set; }
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public IList<string> films { get; set; }
        public IList<string> species { get; set; }
        public IList<string> vehicles { get; set; }
        public IList<string> starships { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
}
