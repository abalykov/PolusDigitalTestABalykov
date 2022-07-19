using BuyersProductsApp.Data;
using BuyersProductsApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Project1.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]

    public class BuyersController : ControllerBase
    {
        private readonly IAppDbContext db;
        private readonly ILogger<BuyersController> log;

        public BuyersController(IAppDbContext db, ILogger<BuyersController> log)
        {
            this.db = db;
            this.log = log;
        }


        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(long id, Buyer buyer)
        {
            var dbItem = await db.Buyers.FindAsync(id);

            if (dbItem == null)
                return NotFound($"Not found object by id = {id}");

            //TODO: Валидация и всякие проверки

            db.Entry(dbItem).State = EntityState.Detached;

            db.Buyers.Attach(buyer);

            db.Entry(buyer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Error while updating item by recId {id}" );

                throw;
            }

            return Ok();
        }

        [HttpPost]
        [Route("delete/{id}")]

        public async Task<IActionResult> Delete(long id)
        {
            var dbItem = await db.Buyers.FindAsync(id);

            if (dbItem == null)
                return NotFound($"Not found object by id = {id}");

            db.Buyers.Remove(dbItem);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Error while deleting item by recId {id}");

                throw;
            }

            return Ok();
        }

        [HttpPost]
        [Route("add")]

        public async Task<IActionResult> Add(Buyer buyer)
        {
            //TODO: Валидация и всякие проверки

            db.Buyers.Add(buyer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                log.LogError(ex, "Error while adding new item");

                throw;
            }

            return Ok();
        }
    }
}
