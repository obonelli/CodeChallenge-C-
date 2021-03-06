using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.Configuration;

namespace TvShowApp.Models
{
    
    public class TvShowView
    {        
        public int Id { get; set; }
        public string Tittle { get; set; }

        public bool favorites { get; set; }
    }
}
