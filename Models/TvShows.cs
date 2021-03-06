using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCodeFirst1.Models
{

    public class TvShows
    {
        public static object Shows { get; internal set; }
        public int Id { get; set; }
        public string Tittle { get; set; }

        public bool favorites { get; set; }

       // public List<Post> Post { get; set; }

        public TvShows()
        {
            favorites = false;

        }


    }

}

