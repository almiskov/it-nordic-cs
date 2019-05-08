using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApplication.DataStore;
using AspApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspApplication.Controllers
{
	[Route("/api/cities")]
	public class CitiesController : Controller
	{
		[HttpGet()]
		public IActionResult GetCities()
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			var cities = citiesDataStore.Cities;

			return Ok(cities);
		}

		[HttpGet("{id}", Name = "GetCity")]
		public IActionResult GetCity(int id)
		{
			var citiesDataStore = CitiesDataStore.GetInstance();
			var city = citiesDataStore.Cities
				.Where(x => x.Id == id)
				.FirstOrDefault();

			if (city == null)
			{
				return NotFound();
			}

			return Ok(city);
		}

		[HttpPost("/api/cities")]
		public IActionResult CreateCity([FromBody] CityCreateModel city)
		{
			if(city == null)
			{
				return BadRequest();
			}

			var citiesDataStore = CitiesDataStore.GetInstance();
			var newCityId = citiesDataStore.Cities
				.Max(x => x.Id) + 1;

			var newCity = new CityGetModel()
			{
				Id = newCityId,
				Name = city.Name,
				Description = city.Description,
				NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
			};

			citiesDataStore.Cities.Add(newCity);

			return CreatedAtRoute(
				"GetCity",
				new { id = newCityId},
				newCity);
		}
	}
}
