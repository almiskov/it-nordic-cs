using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApplication.DataStore;
using AspApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspApplication.Controllers
{
	[Route("/api/cities")]
	public class CitiesController : Controller
	{
		ILogger<CitiesController> _logger;
		ICitiesDataStore _citiesDataStore;

		public CitiesController(ILogger<CitiesController> logger, ICitiesDataStore citiesDataStore)
		{
			_logger = logger;
			_citiesDataStore = citiesDataStore;
		}

		[HttpGet()]
		public IActionResult GetCities()
		{
			_logger.LogInformation($"{nameof(GetCities)} called.");

			var cities = _citiesDataStore.Cities;

			return Ok(cities);
		}

		[HttpGet("{id}", Name = "GetCity")]
		public IActionResult GetCity(int id)
		{
			var city = _citiesDataStore.Cities
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

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var newCityId = _citiesDataStore.Cities
				.Max(x => x.Id) + 1;

			var newCity = new CityGetModel()
			{
				Id = newCityId,
				Name = city.Name,
				Description = city.Description,
				NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
			};

			_citiesDataStore.Cities.Add(newCity);

			return CreatedAtRoute(
				"GetCity",
				new { id = newCityId },
				newCity);
		}
	}
}
