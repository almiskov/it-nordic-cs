using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithSql
{
	public interface IOrderRepository
	{
		int GetOrdersCount();
		List<string> GetOrderList();
		int AddOrder(
			int customerId,
			DateTimeOffset orderDate,
			float? discount,
			List<Tuple<int, int>> productIdCountList);
	}
}
