using Npgsql;
using System;
using System.Data;

namespace BuyersProductsApp.App.Extentions
{
	public static class SqlParametersHelper
	{
		public static NpgsqlParameter AsSqlDateParameter(this DateTime value, string parameterName)
		{
			var t = new NpgsqlParameter(parameterName, value)
			{
				DbType = DbType.Date
			};
			return t;
		}
		public static NpgsqlParameter AsSqlParameter<T>(this T value, string parameterName)
		{
			if (typeof(T) == typeof(object))
			{
				return AsSqlDynamicParameter(value, parameterName);
			}
			var t = new NpgsqlParameter(parameterName, (object)value ?? DBNull.Value);
			if (typeof(T) == typeof(DateTime?) || typeof(T) == typeof(DateTime))
			{
				t.DbType = DbType.DateTime2;
			}
			return t;
		}
		public static NpgsqlParameter AsSqlDynamicParameter(object value, string parameterName)
		{
			if (value != null && (value.GetType() == typeof(DateTime?) || value.GetType() == typeof(DateTime)))
			{
				return new NpgsqlParameter(parameterName, SqlDbType.DateTime2)
				{
					Value = value
				};
			}
			return new NpgsqlParameter(parameterName, value ?? DBNull.Value);
		}
	}
}
