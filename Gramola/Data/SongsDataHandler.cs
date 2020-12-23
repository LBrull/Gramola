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

        public async Task<IEnumerable<Song>> GetSongs()
        {
            return context.Songs;
        } 

        public void AddSong(Song song)
        {
            context.Songs.Add(song);
            context.SaveChanges();
        }
    }
}
