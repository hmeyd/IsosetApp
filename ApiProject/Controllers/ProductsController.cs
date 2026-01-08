using Microsoft.AspNetCore.Mvc;
using ApiProject.Data;
using ApiProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> AfficherAll()
        {
            return Ok(_context.Products.ToList());
        }

        // GET: api/products/1
        [HttpGet("{id}")]
        public ActionResult<Product> Afficher(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            product.DateCreation = DateTime.Now;
            product.DateModification = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Afficher), new { id = product.Id }, product);
        }

        // PUT: api/products/1
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Product updatedProduct)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            product.Nom = updatedProduct.Nom;
            product.Reference = updatedProduct.Reference;
            product.Prix = updatedProduct.Prix;
            product.Quantite = updatedProduct.Quantite;
            product.Categorie = updatedProduct.Categorie;
            product.DateModification = DateTime.Now;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/products/1
        [HttpDelete("{id}")]
        public IActionResult Supprimer(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
