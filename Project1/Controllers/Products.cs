using BuyersProductsApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class Products : ODataController
    {
        private readonly IAppDbContext db;

        public Products(IAppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var ret = db.Products;
            return Ok(ret);
        }

        [EnableQuery]
        [HttpGet]
        public async Task<IActionResult> Get(long key)
        {
            var dbItem = await db.Products.FindAsync(key);
            if (dbItem == null)
            {
                return NotFound($"Not found product with id = {key}");
            }

            return Ok(dbItem);
        }
    }
}
