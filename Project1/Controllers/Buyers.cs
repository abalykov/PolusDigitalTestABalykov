using BuyersProductsApp.Data;
using BuyersProductsApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class Buyers : ODataController
    {
        private readonly IAppDbContext db;

        public Buyers(IAppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var ret = db.Buyers;
            return Ok(ret);
        }

        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> Get(long key)
        {
            var dbItem = await db.Buyers.FindAsync(key);
            if (dbItem == null)
            {
                return NotFound($"Not found item with id = {key}");
            }

            return Ok(dbItem);
        }

        [EnableQuery]
        [HttpPut]
        public IActionResult Put(long key, [FromBody] Buyer buyer)
        {
            return Ok();
        }
    }
}
