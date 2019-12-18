using APM.MVC.Models;
using APM.SL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APM.MVC.Controllers
{
  public class ProductController : Controller
  {

    // GET action
    // When navigating to the page.
    public IActionResult PriceUpdate()
    {
      // Create model
      var productVM = new ProductViewModel();
      productVM.EffectiveDate = DateTime.Now;

      ViewBag.IsAcceptable = false;

      return View(productVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult PriceUpdate(ProductViewModel productVM)
    {
      // Code to save the product

      return View(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Calculate(ProductViewModel productVM)
    {
      var price = productVM.Price;
      var cost = productVM.Cost;

      // Calculate and check the profit margin
      var product = new Product();
      var calculatedMargin = product.CalculateMargin(cost, price);

      // Display the results
      ViewBag.CalculateMargin = calculatedMargin;
      ViewBag.IsAcceptable = calculatedMargin >= 40;

      return View(nameof(PriceUpdate), productVM);
    }

    // GET: Product
    public ActionResult Index()
    {
      return View();
    }

  }
}