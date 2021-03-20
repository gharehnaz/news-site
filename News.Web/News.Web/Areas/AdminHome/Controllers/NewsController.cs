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
    public class NewsController : Controller
    {
        // GET: AdminHome/News
        
            DataContext context = new DataContext();
            public ActionResult Index()
            {
                return View(context.NewsCollection.Include("NewsCategory").ToList());
            }

            public ActionResult Create()
            {
                ViewBag.SelectList = context.NewsCategoryCollection.Include("NewsEntities").ToList();
                return View();
            }
            [HttpPost]
            public ActionResult Create(NewsEntity model, HttpPostedFileBase PictureFile)
            {
                string DefaultAddress = "";
                if (PictureFile != null)
                {
                    DefaultAddress = "/Upload/News/" + Guid.NewGuid().ToString().Substring(0, 8) + PictureFile.FileName;

                    PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));

                    model.PictureUrl = DefaultAddress;
                }
                context.NewsCollection.Add(model);
                context.SaveChanges();
                return RedirectToAction("index");
            }

            public ActionResult Edit(long Id)
            {
                return View(context.NewsCollection.Find(Id));
            }
            [HttpPost]
            public ActionResult Edit(NewsEntity model, HttpPostedFileBase PictureFile)
            {
                NewsEntity Data = context.NewsCollection.Find(model.Id);

                if (PictureFile != null)
                {
                    FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureUrl));
                    if (info.Exists)
                    {
                        info.Delete();
                    }
                    string DefaultAddress = "/Upload/News/" + Guid.NewGuid().ToString().Substring(0, 8) + PictureFile.FileName;

                    PictureFile.SaveAs(Server.MapPath("~" + DefaultAddress));

                    Data.PictureUrl = DefaultAddress;
                }
                Data.Author = model.Author;
                Data.Description = model.Description;
                Data.NewsCategory_Id = model.NewsCategory_Id;
                Data.Title = model.Title;

                context.SaveChanges();
                return RedirectToAction("index");
            }

            public ActionResult Delete(long Id)
            {
                NewsEntity Data = context.NewsCollection.Find(Id);
                FileInfo info = new FileInfo(Server.MapPath("~" + Data.PictureUrl));
                if (info.Exists)
                {
                    info.Delete();
                }
                context.NewsCollection.Remove(Data);

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
