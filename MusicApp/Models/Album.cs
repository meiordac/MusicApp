using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicApp.Models
{
    public class Album
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlbumID { get; set; }
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}