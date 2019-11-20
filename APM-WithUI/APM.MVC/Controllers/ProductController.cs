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
      product.Cost = "100";
      product.Price = "200";
      product.EffectiveDate = DateTime.Now;

      return View(product);
    }

    [HttpPost("{command?}")]
    [ValidateAntiForgeryToken]
    public IActionResult PriceUpdate(ProductViewModel product, string command="")
    {
      if (command == "calculate")
      {
        decimal cost = decimal.Parse(product.Cost);
        decimal price = decimal.Parse(product.Price);

        // Calculate and check the profit margin
        var calculatedMargin = ((price - cost) / price) * 100;

        var isAcceptable = calculatedMargin >= 40;

        // Display the results
        product.ProfitMargin = calculatedMargin;
      }

      return View(product);
    }

    public IActionResult Calculate(ProductViewModel product)
    {
      decimal cost = decimal.Parse(product.Cost);
      decimal price = decimal.Parse(product.Price);

      // Calculate and check the profit margin
      var calculatedMargin = ((price - cost) / price) * 100;

      var isAcceptable = calculatedMargin >= 40;

      // Display the results
      product.ProfitMargin = calculatedMargin;

      return View(nameof(PriceUpdate), product);
    }

    //// GET: Product
    //public ActionResult Index(ProductViewModel model, string command)
    //{
    //  if (command == "calculate")
    //  {
    //    model.ProfitMargin = 25;
    //  }
    //  return View(model);
    //}


    // GET: Product
    public ActionResult Index()
    {
      return View();
    }

    // GET: Product/Details/5
    public ActionResult Details(int id)
    {
      return View();
    }

    // GET: Product/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
      try
      {
        // TODO: Add insert logic here

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Product/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Product/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
      try
      {
        // TODO: Add update logic here

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: Product/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Product/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
      try
      {
        // TODO: Add delete logic here

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}