using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CategoryController : Controller
    {
        CompanyDBContsxt db = new CompanyDBContsxt();
        // GET: Category
        public ActionResult Index(string search = "", int PageNo = 1)
        {
           
            List<Category> categories = db.Categories.Where(temp => temp.CategoryName.Contains(search)).ToList();
            ViewBag.search = search;

            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(categories.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            categories = categories.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category c)
        {
            
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Details(int id)
        {
            
            Category c = db.Categories.Where(temp => temp.CategoryID == id).FirstOrDefault();
            return View(c);
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            
            Category existingCategory = db.Categories.Where(temp => temp.CategoryID == id).FirstOrDefault();

            return View(existingCategory);
        }
        [HttpPost]
        public ActionResult Update(Category c)
        {
           
            Category existingCategory = db.Categories.Where(temp => temp.CategoryID == c.CategoryID).FirstOrDefault();
            existingCategory.CategoryName = c.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
            
        }
        [HttpGet]
        public ActionResult Delete(long id)
        {
           
            Category existingCategory = db.Categories.Where(temp => temp.CategoryID == id).FirstOrDefault();
            return View(existingCategory);
        }
        [HttpPost]
        public ActionResult Delete(long id, Category c)
        {
           
            Category existingCategory = db.Categories.Where(temp => temp.CategoryID ==id).FirstOrDefault();
            db.Categories.Remove(existingCategory);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}