using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Popularity { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}