using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class Artist
    {
        public Artist()
        {
            Albums = new List<Album>();
        }
        public int ID { get; set; }
        public String Href { get; set; }
        public String Name { get; set; }
        public String Popularity { get; set; }
        public List<Album> Albums { get; set; }
    }
}