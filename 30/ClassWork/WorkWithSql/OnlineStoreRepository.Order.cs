using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithSql
{
	public partial class OnlineStoreRepository : IOrderRepository
	{
		public int GetOrdersCount()
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT COUNT(*) FROM dbo.[Order]";

				var result = (int)sqlCommand.ExecuteScalar();

				return result;
			}
		}

		public List<string> GetOrderList()
		{
			var result = new List<string>();

			using (var sqlConnection = GetOpenedSqlConnection())
			{
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "SELECT Id, CustomerId, OrderDate, Discount FROM dbo.[Order] ORDER BY OrderDate DESC";

				using(var sqlDataReader = sqlCommand.ExecuteReader())
				{
					if (!sqlDataReader.HasRows)
					{
						return result;
					}

					int idColumnIndex = sqlDataReader.GetOrdinal("Id");
					int customerIdColumnIndex = sqlDataReader.GetOrdinal("CustomerId");
					int orderDateColumnIndex = sqlDataReader.GetOrdinal("OrderDate");
					int discountColumnIndex = sqlDataReader.GetOrdinal("Discount");

					while (sqlDataReader.Read())
					{
						var id = sqlDataReader.GetInt32(idColumnIndex);
						var customerId = sqlDataReader.GetInt32(customerIdColumnIndex);
						var orderDate = sqlDataReader.GetDateTimeOffset(orderDateColumnIndex);

						var discount = sqlDataReader.IsDBNull(discountColumnIndex)
							? 0
							: sqlDataReader.GetDouble(discountColumnIndex);

						result.Add($"Order Id: {id}\tCustomer Id: {customerId}\tOrder date: {orderDate}\tDiscount: {discount}");
					}

					return result;
				}
			}
		}

		public int AddOrder(int customerId, DateTimeOffset orderDate, float? discount, List<Tuple<int, int>> productIdCountList)
		{
			using (var sqlConnection = GetOpenedSqlConnection())
			{
				
				var sqlCommand = sqlConnection.CreateCommand();
				sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

				// Adding order
				sqlCommand.CommandText = "dbo.AddOrder";

				sqlCommand.Parameters.AddWithValue("@customerId", customerId);
				sqlCommand.Parameters.AddWithValue("@orderDate", orderDate);
				sqlCommand.Parameters.AddWithValue("@discount", discount);

				var idParameter = new SqlParameter("id", System.Data.SqlDbType.Int);
				idParameter.Direction = System.Data.ParameterDirection.Output;

				sqlCommand.Parameters.Add(idParameter);

				sqlCommand.ExecuteNonQuery();

				var orderId = (int)idParameter.Value;

				// Adding order items
				sqlCommand.CommandText = "dbo.AddOrderItem";

				foreach (var productIdCountPair in productIdCountList)
				{
					sqlCommand.Parameters.Clear();
					sqlCommand.Parameters.AddWithValue("@orderId", orderId);
					sqlCommand.Parameters.AddWithValue("@productId", productIdCountPair.Item1);
					sqlCommand.Parameters.AddWithValue("@numberOfItems", productIdCountPair.Item2);

					sqlCommand.ExecuteNonQuery();
				}

				return orderId;
			}
		}
	}
}
