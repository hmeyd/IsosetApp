using DemoMvcApp.Data;
using DemoMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
//using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Linq;

namespace DemoMvcApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Products
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        // Get : /Product by Id
        public IActionResult Afficher()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Afficher(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return View("IndexErreur") ;
            
            return RedirectToAction("Edit1", new { id = id });
        }

        public IActionResult Edit1(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

           
            return View(product);
        }


        // Get all productes
        [HttpGet]
        public IActionResult AfficherAll()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult Supprimer()
        {
            return View();
        }

        // Suprimer un product by Id
        [HttpPost]
        public IActionResult Supprimer(int Id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return NotFound(Id);
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return View("Index");
        }


        // GET : /Products/Modifier
        public IActionResult Modifier()
        {
            return View();
        }

        // POST : /Products/Modifier
        [HttpPost]
        public IActionResult Modifier(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return View("IndexErreur");

            // Redirection vers l'action Edit
            return RedirectToAction("Edit", new { id = id });
        }

        // GET : /Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST : /Products/Edit
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (!ModelState.IsValid)
                return View(updatedProduct);

            var product = _context.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null)
                return NotFound();

            product.Nom = updatedProduct.Nom;
            product.Reference = updatedProduct.Reference;
            product.Prix = updatedProduct.Prix;
            product.Quantite = updatedProduct.Quantite;
            product.Categorie = updatedProduct.Categorie;
            product.DateModification = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
