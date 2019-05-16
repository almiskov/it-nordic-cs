using System.Collections.Generic;

namespace AspApplication.DataStore
{
	public interface ICitiesDataStore
	{
		List<CityDataStoreModel> Cities { get; }
	}
}
