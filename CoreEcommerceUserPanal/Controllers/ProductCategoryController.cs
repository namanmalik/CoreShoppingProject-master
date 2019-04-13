using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreEcommerceUserPanal.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ShoppingProjectFinalContext _context;
        public ProductCategoryController(ShoppingProjectFinalContext context)
        {
            _context = context;
        }
        //  ShoppingProjectFinalContext context = new ShoppingProjectFinalContext();
        public IActionResult Index()
        {

            var pc = _context.Categories.ToList();
            return View(pc);
        }
        public IActionResult ProductDisplay(int? id)
        {
            var p = _context.Products.Where(x => x.ProductCategoryId == id).ToList();
            return View(p);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var productcategory = await _context.Categories.FindAsync(id);

            if (productcategory == null)
            {
                return NotFound();
            }
            return Ok(productcategory);
        }
    }
}