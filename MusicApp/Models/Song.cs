using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public int ArtistID { get; set; }
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public double Popularity { get; set; }
        public double Length { get; set; }
    }
}