using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diganta.Domain.Entities;

namespace Diganta.Domain.RepositoryInterfaces
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> Get();
        Blog Get(int id);
        bool Post(Blog blog);
        bool Put(Blog blog);
        bool Delete(int id);
    }
}
