using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gramola.Models;
using System.IO;
using Gramola.Data;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace Gramola.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SongsDataHandler songsDataHandler = new SongsDataHandler();
        private string songsPath = @"C:\Users\Laura\Music\";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public PartialViewResult Biblioteca()
        {
            List<Song> allSongs = songsDataHandler.GetSongs().ToList();

            return PartialView("Views/Partial/Biblioteca.cshtml", allSongs);
            
        }
        //[HttpGet("{searchWord}/{searchStyle}")]
        public PartialViewResult SearchSongs(string searchWord, string searchStyle)
        {
            SongsDataHandler sdh = new SongsDataHandler();
            IEnumerable<Song> songs = null;
            if (searchStyle == "null")
            {
                songs = sdh.GetSongsByText(searchWord).ToList();
            }
            else
            {

            }
            return PartialView("Views/Partial/Biblioteca.cshtml", songs);
        }

        [HttpGet]
        public async Task<FileStreamResult> GetSong(int id)
        {
            SongsDataHandler sdh = new SongsDataHandler();
            Song song = sdh.GetSongById(id);

            var filename = song.path;
            var memory = new MemoryStream();
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            string downloadName =song.artist.ToString() + '-' + song.name.ToString() + ".mp3"; 

            return File(memory, "audio/mpeg", downloadName, true);
        }

        [HttpPost]
        public IActionResult UploadSong(UploadingModel uploadingModel)
        {
            try
            {
                var pathToSave = songsPath + uploadingModel.path + ".mp3";

                Song newSong = new Song();
                newSong.artist = uploadingModel.artist;
                newSong.extension = "mp3";
                newSong.name = uploadingModel.name;
                newSong.path = pathToSave;
                newSong.SetStyle(uploadingModel.style);
                newSong.uploader = uploadingModel.uploader;

                if (ModelState.IsValid)
                {
                    using (FileStream fs = System.IO.File.Create(pathToSave))
                    {
                        uploadingModel.fileSong.CopyTo(fs);
                        fs.Flush();
                    }
                    songsDataHandler.AddSong(newSong);
                    return Ok(200);
                }
                else
                {
                    return StatusCode(422);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
