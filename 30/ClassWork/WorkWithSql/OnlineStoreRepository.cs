﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WorkWithSql
{
	public partial class OnlineStoreRepository
	{
		private readonly string _connectionString;

		public OnlineStoreRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		private SqlConnection GetOpenedSqlConnection()
		{
			var sqlConnection = new SqlConnection(_connectionString);
			sqlConnection.Open();
			return sqlConnection;
		}
	}
}
