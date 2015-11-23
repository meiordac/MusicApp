using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public String AlbumID { get; set; }
        public String Name { get; set; }
        public String Popularity { get; set; }
        public decimal? Length { get; set; }
        public String Href { get; set; }
        public string ArtistId { get; internal set; }
    }
}