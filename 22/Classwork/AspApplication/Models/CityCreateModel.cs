﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApplication.Models
{
	public class CityCreateModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int NumberOfPointsOfInterest { get; set; }
	}
}
