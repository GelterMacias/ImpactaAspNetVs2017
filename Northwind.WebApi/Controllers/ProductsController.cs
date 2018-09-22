using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Northwind.Repositorios.SqlServer;

namespace Northwind.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private NorthwindDbContext db = new NorthwindDbContext();

        public ProductsController()
        {
            //Desabilita o Lazy Load
            db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Products
        public IQueryable<Product> GetProducts() //Precisa ter o verbo no inicio do nome do metodo (GET)
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))] //Referente documentação
        public async Task<IHttpActionResult> GetProduct(int id) //Task pertence ao System.Threading
        {
            //async / await - a consulta não interrompe o servidor de IIES
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("api/products/{productId}/supplier")]
        public async Task<IHttpActionResult> GetProductSupplier(int productId)
        {
            //var fornecedor = db.Suppliers.Find(db.Products.Find(productId).SupplierID).CompanyName;
            //Precisa do Include porque esta desligado o proxy
            var fornecedor = await db.Products.Include(p => p.Supplier).Where(p => p.ProductID == productId).Select(p => p.Supplier).SingleOrDefaultAsync();

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}