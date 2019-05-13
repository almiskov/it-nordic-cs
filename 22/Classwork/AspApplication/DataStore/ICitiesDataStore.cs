using AspApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApplication.DataStore
{
	public interface ICitiesDataStore
	{
		List<CityGetModel> Cities { get; }
	}
}
