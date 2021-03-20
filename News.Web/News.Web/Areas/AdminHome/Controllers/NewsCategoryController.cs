using News.Web.Models;
using News.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Web.Areas.AdminHome.Controllers
{

    public class NewsCategoryController : Controller
    {
        // GET: AdminHome/NewsCategory
        DataContext context = new DataContext();
        public ActionResult Index()
        {
            return View(context.NewsCategoryCollection.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsCategoryEntity model)
        {
            context.NewsCategoryCollection.Add(model);
            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(long Id)
        {
            return View(context.NewsCategoryCollection.Find(Id));
        }
        [HttpPost]
        public ActionResult Edit(NewsCategoryEntity model)
        {
            context.Entry<NewsCategoryEntity>(model).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(long Id)
        {
            context.NewsCategoryCollection.Remove(context.NewsCategoryCollection.Find(Id));

            context.SaveChanges();
            return RedirectToAction("index");
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}