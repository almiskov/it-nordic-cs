using System.Linq;
using AspApplication.Models;
using AspApplication.Storage.Core;
using Microsoft.AspNetCore.JsonPatch;
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

			var outputCities = _citiesDataStore.Cities
				.Select(x => new CityGetModel()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					NumberOfPointsOfInterest = x.NumberOfPointsOfInterest
				});

			return Ok(outputCities);
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

			var outputCity = new CityGetModel()
			{
				Id = city.Id,
				Name = city.Name,
				Description = city.Description,
				NumberOfPointsOfInterest = city.NumberOfPointsOfInterest
			};

			return Ok(outputCity);
		}

		[HttpDelete("{id}")]
		public IActionResult RemoveCity(int id)
		{
			var city = _citiesDataStore.Cities
				.Where(x => x.Id == id)
				.FirstOrDefault();

			if (city == null)
			{
				return NotFound();
			}

			_citiesDataStore.Cities.Remove(city);

			return Ok();
		}

		[HttpPost("/api/cities")]
		public IActionResult CreateCity([FromBody] CityCreateModel city)
		{
			if (city == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var newCityId = _citiesDataStore.Cities
				.Max(x => x.Id) + 1;

			var newCity = new CityDataStoreModel()
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

		[HttpPut("{id}")]
		public IActionResult ReplaceCity(int id, [FromBody] CityPutModel newCity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var city = _citiesDataStore.Cities
				.Where(x => x.Id == id)
				.FirstOrDefault();

			if (city == null)
			{
				return NotFound();
			}

			city.Name = newCity.Name;
			city.Description = newCity.Description;
			city.NumberOfPointsOfInterest = newCity.NumberOfPointsOfInterest;

			return NoContent();
		}

		[HttpPatch("{id}")]
		public IActionResult PatchCity(int id, [FromBody] JsonPatchDocument<CityPatchModel> patch)
		{
			if (patch == null)
			{
				return BadRequest();
			}

			var city = _citiesDataStore.Cities
				.Where(x => x.Id == id)
				.FirstOrDefault();

			if (city == null)
			{
				return NotFound();
			}

			var cityToPatch = new CityPatchModel(city);

			patch.ApplyTo(cityToPatch);

			if (!TryValidateModel(cityToPatch))
			{
				return BadRequest(ModelState);
			}

			if(city.Name != cityToPatch.Name)
				city.Name = cityToPatch.Name;
			if (city.Description != cityToPatch.Description)
				city.Description = cityToPatch.Description;
			if (city.NumberOfPointsOfInterest != cityToPatch.NumberOfPointsOfInterest)
				city.NumberOfPointsOfInterest = cityToPatch.NumberOfPointsOfInterest;

			return NoContent();
		}
	}
}
