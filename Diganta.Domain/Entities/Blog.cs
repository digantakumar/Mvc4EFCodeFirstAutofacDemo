using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diganta.Domain.Entities
{
    //If use abstract you cannot new up an instance of this class, only use to inherite
    public class Blog
    {
        public int Id {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        //public string Test { get; set; }

        public ICollection<Post> Posts { get; set; } 
    }
}
