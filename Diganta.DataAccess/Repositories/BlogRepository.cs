using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Diganta.DataAccess.Context;
using Diganta.Domain.Entities;
using Diganta.Domain.RepositoryInterfaces;

namespace Diganta.DataAccess.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        readonly DigantaContext _db = new DigantaContext();

        public IEnumerable<Blog> Get()
        {
            return _db.Blogs.ToList();
        }

        public Blog Get(int id = 0)
        {
            Blog blog = _db.Blogs.Find(id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }


        public bool Post(Blog blog)
        {
            try
            {
                _db.Blogs.Add(blog);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Put(Blog blog)
        {
            try
            {
                _db.Entry(blog).State = EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                Blog blog = _db.Blogs.Find(id);
                _db.Blogs.Remove(blog);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
