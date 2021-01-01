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

        [HttpGet]
        public async Task<FileStreamResult> GetSong(int id)
        {
            SongsDataHandler sdh = new SongsDataHandler();
            Song song = sdh.getSongById(id);

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
            
            return Ok();
        }
    }
}
