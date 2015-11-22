using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MusicApp.Models;

namespace MusicApp.DAL
{
    public class MusicInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MusicContext>
    {
        protected override void Seed(MusicContext context)
        {

            var artists = new List<Artist>();

            artists.ForEach(s => context.Artists.Add(s));
            context.SaveChanges();

            var albums = new List<Album>();
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();
            var songs = new List<Song>();
            songs.ForEach(s => context.Songs.Add(s));
            context.SaveChanges();
        }
    }
}