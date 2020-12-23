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
            List<Song> allSongs = songsDataHandler.GetSongs().Result.ToList();
            string path = @"C:\Users\Laura\Music";
            DirectoryInfo di = new DirectoryInfo(path);
            //foreach (var fi in di.GetFiles())
            //{
            //    Song cancion = new Song();
            //    cancion.name = fi.Name;
            //    //cancion.setArtist(fi.FullName.Split('.')[1]);
            //    cancion.extension =fi.FullName.Split('.')[1];
            //    cancion.path = fi.FullName;

            //    canciones.Add(cancion);
            //}


            return PartialView("Views/Partial/Biblioteca.cshtml", allSongs);
            
        }

        public ActionResult PlaySong(int id)
        {
            var bytes = new byte[0];
            string fileLocation = @"C:\Users\Laura\Music\AC_DC - Highway to Hell (Official Video) (128kbit_AAC).mp3";

            using (var fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read))
            {
                var br = new BinaryReader(fs);
                long numBytes = new FileInfo(fileLocation).Length;
                var buff = br.ReadBytes((int)numBytes);
                return File(buff, "audio/mpeg", "songg.mp3");
            }
        }
    }
}
