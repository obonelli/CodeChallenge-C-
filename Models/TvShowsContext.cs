using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EntityFrameworkCodeFirst1.Models
{
    class TvShowsContext : DbContext
    {

        //Constructor
        public TvShowsContext()
        {
           

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-AT1GU9C\BCDEMO;Initial Catalog=TvShows;Integrated Security=True;User ID=sa;Password=proyecto2021;");
            optionsBuilder.UseSqlServer(con);
            base.OnConfiguring(optionsBuilder);
        }

     
        public DbSet<TvShows> Shows { get; set; }
    }
}
