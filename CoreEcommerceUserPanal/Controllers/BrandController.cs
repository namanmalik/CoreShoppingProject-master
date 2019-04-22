using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEcommerceUserPanal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreEcommerceUserPanal.Controllers
{
    public class BrandController : Controller
    {
            //private readonly ShoppingProjectFinalContext _context;
            //public BrandController(ShoppingProjectFinalContext context)
            //{
            //    _context = context;
            //}
        ShoppingProjectFinalContext _context = new ShoppingProjectFinalContext();

        public ViewResult Index()
        {
            var brand = _context.Brands.ToList();
            return View(brand);
        }
        public IActionResult ProductDisplay(int id)
        {
            var p = _context.Products.Where(x => x.BrandId == id).ToList();
            return View(p);
        }
    }
}