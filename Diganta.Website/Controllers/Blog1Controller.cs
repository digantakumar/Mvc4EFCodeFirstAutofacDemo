using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diganta.Domain.Entities;
using Diganta.Domain.RepositoryInterfaces;

namespace Diganta.Website.Controllers
{
    public class Blog1Controller : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public Blog1Controller(IBlogRepository blogRepository)
        {
            if (blogRepository == null) throw new ArgumentNullException("blogRepository");
            _blogRepository = blogRepository;
        }

        public ActionResult Index()
        {
            return View(_blogRepository.Get());
        }

        //
        // GET: /Blog1/Details/5

        public ActionResult Details(int id = 0)
        {
            Blog blog = _blogRepository.Get(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // GET: /Blog1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Blog1/Create

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var isPosted = _blogRepository.Post(blog);
                if (isPosted)
                    return RedirectToAction("Index");
            }

            return View(blog);
        }

        //
        // GET: /Blog1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Blog blog = _blogRepository.Get(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Blog1/Edit/5

        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            if (ModelState.IsValid)
            {
                var isPut = _blogRepository.Put(blog);
                if (isPut)
                    return RedirectToAction("Index");
            }
            return View(blog);
        }

        //
        // GET: /Blog1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Blog blog = _blogRepository.Get(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Blog1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _blogRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}

    }
}