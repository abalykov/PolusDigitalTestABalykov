using BuyersProductsApp.App.Extentions;
using BuyersProductsApp.Data;
using BuyersProductsApp.Data.Entities.Projections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace BuyersProductsApp.App.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]

    public class ReportsController : ControllerBase
    {
        private readonly IAppDbContext db;
        private readonly ILogger<ReportsController> log;

        public ReportsController(IAppDbContext db, ILogger<ReportsController> log)
        {
            this.db = db;
            this.log = log;
        }

        [HttpGet]
        [Route("somereport")]
        public async Task<IActionResult> SomeReport()
        {
            // Реализовать отчет который выводил бы всех покупателей и суммарную стоимость
            // совершенных покупок. Параметрами отчета: дата совершения покупок.
            // Сортировка отчета должна осуществляться по убыванию суммарной стоимости покупок.
            var sql = $@"with r as (
	                select p.""BuyerId"" as buyer_id, sum(pr.""Summ"") as ""PurchaseSum""
	                from ""PurchaseRows"" pr
		                join ""Purchases"" p on p.""RecId"" = pr.""PurchaseId""
	                where p.""PurchaseDate"" >= @start_date AND p.""PurchaseDate"" < @end_date
	                group by p.""BuyerId""

                )
                select b.""FirstName"", b.""SecondName"", b.""MiddleName"", r.""PurchaseSum""
	                from r
		                join ""Buyers"" b on b.""RecId"" = r.buyer_id
                order by r.""PurchaseSum"" desc";

            var startDate = new DateTime(DateTime.Now.Year, 1, 1); // с начала текущего года
            var endDate = DateTime.Now.Date.AddDays(1); // по сегодня

            var sqlParameters = new List<NpgsqlParameter>
            {
                 startDate.Date.AsSqlDateParameter("@start_date"),
                 endDate.Date.AddDays(1).AsSqlDateParameter("@end_date"),
            };

            var ms = new MemoryStream();

            try
            {
                var reportItems = await db.QueryExt<SomeReportProjection>()
                    .FromSqlRawExt(sql, sqlParameters.ToArray()).ToListAsync();

                //TODO: тут используем полученные данные и пишем в какой нужно файл 
                var sw = new StreamWriter(ms);

                await sw.WriteLineAsync($"Отчет сформирован за период с {startDate} по {endDate} - найдено {reportItems.Count} записей");

                foreach (var item in reportItems)
                {
                    await sw.WriteLineAsync($"{item.FirstName} {item.SecondName} {item.MiddleName} - {item.PurchaseSum}р.");
                }

                sw.Flush();
                ms.Position = 0;

            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Error while generate report");

                throw;
            }

            return new FileStreamResult(ms, MediaTypeNames.Text.Plain);
        }
    }
}
