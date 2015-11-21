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

            var artists = new List<Artist>
            {
            new Artist{Name="Foo Fighters",Popularity=0.8},
            new Artist{Name="Kommil Foo",Popularity=0.29},
            new Artist{Name="Foo",Popularity=0.03}

            };

            artists.ForEach(s => context.Artists.Add(s));
            context.SaveChanges();

            var albums = new List<Album>
            {
            new Album{Name="Greatest Hits",ArtistID=1,},
            new Album{Name="Echoes, Silence, Patience & Grace",ArtistID=2,},
            new Album{Name="Wasting Light",ArtistID=3,},
            };
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();
            var songs = new List<Song>
            {
            new Song{ArtistID=1,AlbumID=1,Name="Wasting time", Popularity=8.4, Length=3.4},
            new Song{ArtistID=1,AlbumID=2,Name="Speed of light", Popularity=10, Length=5},
            new Song{ArtistID=1,AlbumID=3,Name="Enjoy the ride", Popularity=3, Length=2}

            };
            songs.ForEach(s => context.Songs.Add(s));
            context.SaveChanges();
        }
    }
}