using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Diganta.DataAccess.Context;
using Diganta.Domain.Entities;
using Diganta.Domain.RepositoryInterfaces;
using Diganta.Website.Models.Diganta;

namespace Diganta.Website.Controllers
{
    public class BlogController : ApiController
    {
        private DigantaContext db = new DigantaContext();

        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            if (blogRepository == null) throw new ArgumentNullException("blogRepository");
            _blogRepository = blogRepository;
        }


        // GET api/Blog
        public IEnumerable<Blog> GetBlogs()
        {
            return _blogRepository.Get();
        }

        // GET api/Blog/5
        public Blog GetBlog(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return blog;
        }

        // PUT api/Blog/5
        public HttpResponseMessage PutBlog(int id, Blog blog)
        {
            if (ModelState.IsValid && id == blog.Id)
            {
                db.Entry(blog).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, blog);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Blog
        public HttpResponseMessage PostBlog(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, blog);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = blog.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Blog/5
        public HttpResponseMessage DeleteBlog(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Blogs.Remove(blog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, blog);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}