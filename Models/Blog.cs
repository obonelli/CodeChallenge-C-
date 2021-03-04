using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCodeFirst1.Models
{

    class Blog
    {
        public static object Blogs { get; internal set; }
        public int Id { get; set; }
        public string URL { get; set; }

        public bool favoritos { get; set; }

        public List<Post> Post { get; set; }

        public Blog()
        {
            favoritos = false;

        }


    }

    class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int IdBlog  { get; set; }

        public Blog blog { get; set; }
    }
}
