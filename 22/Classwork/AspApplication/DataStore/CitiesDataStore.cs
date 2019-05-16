using System.Collections.Generic;

namespace AspApplication.DataStore
{
	public class CitiesDataStore : ICitiesDataStore
	{
		public List<CityDataStoreModel> Cities { get; private set; }

		public CitiesDataStore()
		{
			Cities = new List<CityDataStoreModel>()
				{
					new CityDataStoreModel {Id = 1, Name = "Moscow", Description = "The capital of Russia" },
					new CityDataStoreModel {Id = 2, Name = "New York", Description = "One of the biigest cities in the world"},
					new CityDataStoreModel {Id = 3, Name = "Stary Oskol", Description = "Just good city" }
				};
		}
	}
}
