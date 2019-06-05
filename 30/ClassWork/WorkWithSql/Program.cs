using System;
using System.Collections.Generic;

namespace WorkWithSql
{
	class Program
	{
		static void Main(string[] args)
		{
			const string connectionStringTemplate =
				"Data Source={0};" +
				"Initial Catalog={1};" +
				"Integrated Security=true";

			string connectionString = 
				string.Format(
					connectionStringTemplate,
					@"localhost\SQLEXPRESS",
					"OnlineStore");

			var repository = new OnlineStoreRepository(connectionString);

			//TestMethod1(repository);

			TestAddOrders(repository);


		}

		private static void TestMethod1(OnlineStoreRepository repository)
		{
			int newId = repository.AddProduct("Суперчасы", (decimal)45245.212);
			Console.WriteLine($"New product with id = {newId} added");

			int productCount = repository.GetProductCount();

			Console.WriteLine($"Number of products: {productCount}");

			var products = repository.GetProductList();
			foreach (string s in products)
			{
				Console.WriteLine(s);
			}

			int orderCount = repository.GetOrdersCount();

			var orders = repository.GetOrderList();
			foreach (string s in orders)
			{
				Console.WriteLine(s);
			}
		}

		private static void TestAddOrders(OnlineStoreRepository repository)
		{
			int customerId = 5;
			DateTimeOffset orderDate = DateTimeOffset.Now;
			float discount = 0;
			List<Tuple<int, int>> productIdCountList = new List<Tuple<int, int>>
			{
				new Tuple<int, int>(1,1),
				new Tuple<int, int>(3,2),
				new Tuple<int, int>(2,4),
				new Tuple<int, int>(4,2),
			};


			repository.AddOrder(customerId, orderDate, discount, productIdCountList);
		}
	}
}
