using System.Collections.Generic;

namespace AspApplication.Storage.Core
{
	public interface ICitiesDataStore
	{
		List<CityDataStoreModel> Cities { get; }
	}
}
