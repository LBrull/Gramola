using Gramola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramola.Data
{
    public class SongsDataHandler
    {
        private GramolaContext context;

        public SongsDataHandler ()
        {
            context = new GramolaContext(new Microsoft.EntityFrameworkCore.DbContextOptions<GramolaContext>());
        }

        public IEnumerable<Song> GetSongs()
        {
            try
            {
                var songs = context.Songs.OrderBy(s => s.artist).ThenBy(s => s.name);
                return songs;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddSong(Song song)
        {
            context.Songs.Add(song);
            context.SaveChanges();
        }

        public Song GetSongById(int id)
        {
            return context.Songs.Find(id);

        }

        public IEnumerable<Song> GetSongsByText(string text)
        {
            var songs = context.Songs.Where(s => s.artist.ToLower().Contains(text.ToLower()) || s.name.ToLower().Contains(text.ToLower()));
            return songs.OrderBy(s => s.artist).ThenBy(s => s.name);

        }
    }
}
