using System;
using System.Collections.Generic;
using iQuest.Terra;

namespace iQuest.TerraPlus
{
    public class ContinentPlus
    {
        private readonly List<Country> countries = new List<Country>();

        public ContinentPlus()
        {
        }

        public ContinentPlus(IEnumerable<Country> countries)
        {
            if (countries == null) throw new ArgumentNullException(nameof(countries));

            this.countries.AddRange(countries);
        }

        public IEnumerable<Country> EnumerateCountriesByName()
        {
            countries.Sort();
            return countries;
        }

        public IEnumerable<Country> EnumerateCountriesByCapital()
        {
            List<Country> capitalAsName = new List<Country>();
            Country temporary;
            
            foreach(var country in countries) 
            {
                if(country == null)
                    temporary = null;
                else
                    temporary = new Country(country.Capital , country.Name);
                
                capitalAsName.Add(temporary);
            }

            countries.Clear();
            capitalAsName.Sort();

            foreach (var country in capitalAsName)
            {
                if (country == null)
                    temporary = null;
                else
                    temporary = new Country(country.Capital, country.Name);
                
                countries.Add(temporary);
            }

            return countries;
        }
    }
}