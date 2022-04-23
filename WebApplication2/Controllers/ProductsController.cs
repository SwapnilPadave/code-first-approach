using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDBContsxt db = new CompanyDBContsxt();
        // GET: Products
        public ActionResult Index(string search="", int PageNo=1)
        {
            
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            ViewBag.search = search;

            int NoOfRecordsPerPage = 10;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(products);
        }
        public ActionResult Details(int id)
        {
            
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            ViewBag.categories = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        [HttpGet]
        public ActionResult Update(long id)
        {
            
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.categories = db.Categories.ToList();
            
            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult Update(Product p)
        {
            
            Product existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            existingProduct.ProductName = p.ProductName;
            existingProduct.CategoryID = p.CategoryID;
            


            db.SaveChanges();
            return RedirectToAction("Index", "Products");

        }
        public ActionResult Delete(long id)
        {
            
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            
            Product existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}