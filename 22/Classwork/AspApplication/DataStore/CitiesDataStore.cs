using AspApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApplication.DataStore
{
	public class CitiesDataStore : ICitiesDataStore
	{
		public List<CityGetModel> Cities { get; private set; }

		public CitiesDataStore()
		{
			Cities = new List<CityGetModel>()
				{
					new CityGetModel {Id = 1, Name = "Moscow", Description = "The capital of Russia" },
					new CityGetModel {Id = 2, Name = "New York", Description = "One of the biigest cities in the world"},
					new CityGetModel {Id = 3, Name = "Stary Oskol", Description = "Just good city" }
				};
		}
	}
}
