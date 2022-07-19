using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuyersProductsApp.Data
{
    public static class ContextExtensions
    {
        public static DbSet<T> QueryExt<T>(this IAppDbContext context) where T : class
        {
            return context.Set<T>();
        }

        public static IQueryable<T> FromSqlRawExt<T>(this DbSet<T> dbset, string sql, params NpgsqlParameter[] parameters) where T : class
        {
            return dbset.FromSqlRaw(sql, parameters.Cast<object>().ToArray());
        }
    }
}
