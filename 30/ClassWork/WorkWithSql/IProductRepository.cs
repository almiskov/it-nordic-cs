using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithSql
{
	public interface IProductRepository
	{
		int GetProductCount();
		List<string> GetProductList();
		int AddProduct(string name, decimal price);
	}
}
