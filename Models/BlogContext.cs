using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EntityFrameworkCodeFirst1.Models
{
    class BlogContext : DbContext
    {

        //Constructor
        public BlogContext()
        {
           

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AT1GU9C\BCDEMO;Initial Catalog=Blog_DB;Integrated Security=True;User ID=sa;Password=proyecto2021;");
            optionsBuilder.UseSqlServer(con);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
