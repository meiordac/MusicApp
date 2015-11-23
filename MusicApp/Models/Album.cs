using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zirpl.Spotify.MetadataApi;


namespace MusicApp.Models
{
    public class Album
    {
        public Album()
        {
      
        }

        public int ID { get; set; }
        public string Href { get; set; }
        public String Name { get; set; }
        public string Popularity { get; set; }
        public String Released { get; set; }
        public String ArtistId { get; set; }
        public String Artist { get; set; }
        public String NameLongest { get; set; }
        public decimal? LengthLongest { get; set; }

    }
}
