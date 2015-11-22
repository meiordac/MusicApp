using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicApp.DAL;
using MusicApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Zirpl.Spotify.MetadataApi;

namespace MusicApp.Controllers
{
    public class HomeController : Controller
    {

        private MusicContext db = new MusicContext();
        public ActionResult Index(string searchString)
        {
            List<Zirpl.Spotify.MetadataApi.Artist> artists = new List<Zirpl.Spotify.MetadataApi.Artist>();
            if (searchString != null)
                artists = new SpotifyMetadataApiClient().SearchArtists(searchString).Artists;
            return View(artists.ToList());
        }

        // GET: Artists/Create
        public ActionResult Save(Zirpl.Spotify.MetadataApi.Artist artist)
        {
            SaveArtist(artist);
            List<Zirpl.Spotify.MetadataApi.Album> albums = new List<Zirpl.Spotify.MetadataApi.Album>();
            if (artist.Albums.Count == 0)
                albums = new SpotifyMetadataApiClient().SearchAlbums(artist.Name).Albums;
            else
                albums = artist.Albums;

            foreach (Zirpl.Spotify.MetadataApi.Album album in albums)
            {
                SaveAlbum(album, artist);
            }

            List<Zirpl.Spotify.MetadataApi.Track> tracks = new SpotifyMetadataApiClient().SearchTracks(artist.Name).Tracks;
            foreach (Zirpl.Spotify.MetadataApi.Track track in tracks)
            {
                SaveTrack(track, artist);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public void SaveArtist(Zirpl.Spotify.MetadataApi.Artist artist)
        {
            MusicApp.Models.Artist a = new Models.Artist();
            a.Name = artist.Name;
            a.Href = artist.Href;
            a.Popularity = artist.Popularity;
            //if (ModelState.IsValid)
            {
                db.Artists.Add(a);
                db.SaveChanges();
            }
        }


        [HttpPost]
        public void SaveAlbum(Zirpl.Spotify.MetadataApi.Album album, Zirpl.Spotify.MetadataApi.Artist artist)
        {
            var result = new SpotifyMetadataApiClient().LookupAlbum(album.Href);
            MusicApp.Models.Album a = new Models.Album();
            a.Name = result.Name;
            a.Href = album.Href;
            a.ArtistId = artist.Href;
            a.Popularity = album.Popularity;
            a.Artist = result.Artist;
            a.Released = result.Released;

            //if (ModelState.IsValid)
            if(result.Artist == artist.Name)
            {
                db.Albums.Add(a);
                db.SaveChanges();
            }
        }

        [HttpPost]
        public void SaveTrack(Zirpl.Spotify.MetadataApi.Track track, Zirpl.Spotify.MetadataApi.Artist artist)
        {

            MusicApp.Models.Song s = new Models.Song();
            s.Name = track.Name;
            s.Href = track.Href;
            s.Length = track.Length;
            s.Href = track.Href;
            s.ArtistId = artist.Href;
            s.Popularity = track.Popularity;

            //if (ModelState.IsValid)
            {
                db.Songs.Add(s);
                db.SaveChanges();
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}