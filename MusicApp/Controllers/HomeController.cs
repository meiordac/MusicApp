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
            //return View();
            List<Zirpl.Spotify.MetadataApi.Album> albums = new List<Zirpl.Spotify.MetadataApi.Album>();
            if (artist.Albums.Count == 0)
                albums = new SpotifyMetadataApiClient().SearchAlbums(artist.Name).Albums;
            //Zirpl.Spotify.MetadataApi.Artist artist;
            else
                albums = artist.Albums;

            foreach (Zirpl.Spotify.MetadataApi.Album album in albums)
            {

                MusicApp.Models.Album a = new Models.Album();
                a.Name = album.Name;
                a.Href = album.Href;
                //a.Artists = album.Artists;
                a.ArtistId = album.ArtistId;
                a.Popularity = album.Popularity;
                a.Artist = artist.Name;
                //a.ArtistID = int.Parse(album.ArtistId);
                SaveAlbum(a);
            }
            return RedirectToAction("About");
        }


        [HttpPost]
        public void SaveAlbum(MusicApp.Models.Album newAlbum)
        {

            //if (ModelState.IsValid)
            {
                db.Albums.Add(newAlbum);
                db.SaveChanges();
            }
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void SaveAlbum([Bind(Include = "AlbumID,ArtistID,Name")] MusicApp.Models.Album album)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Your application description page.";
                db.Albums.Add(album);
                db.SaveChanges();
               
            }
        }
        */
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