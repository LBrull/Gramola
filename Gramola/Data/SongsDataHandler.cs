using Gramola.Models;
using System.Collections.Generic;
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
            return context.Songs;
        }

        public void AddSong(Song song)
        {
            context.Songs.Add(song);
            context.SaveChanges();
        }

        public Song getSongById(int id)
        {
            return context.Songs.Find(id);

        }
    }
}
