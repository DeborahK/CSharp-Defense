using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APM.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APM.MVC.Controllers
{
  public class ProductController : Controller
  {

    // GET action
    // When navigating to the page.
    public IActionResult PriceUpdate()
    {
      // Create model
      var product = new ProductViewModel();
      product.EffectiveDate = DateTime.Now;

      ViewBag.IsAcceptable = false;

      return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PriceUpdate(ProductViewModel product)
    {
      // Code to save the product

      return View(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calculate(ProductViewModel product)
    {
      decimal cost = decimal.Parse(product.Cost);
      decimal price = decimal.Parse(product.Price);

      // Calculate and check the profit margin
      var calculatedMargin = ((price - cost) / price) * 100;

      // Display the results
      ViewBag.CalculateMargin = calculatedMargin;
      ViewBag.IsAcceptable = calculatedMargin >= 40; 

      return View(nameof(PriceUpdate), product);
    }

    // GET: Product
    public ActionResult Index()
    {
      return View();
    }

  }
}