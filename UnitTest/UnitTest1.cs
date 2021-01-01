using Gramola.Data;
using Gramola.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetAllSongs()
        {
            var sdh = new SongsDataHandler();
            var expectedCount = 2;
            IEnumerable<Song> songs = sdh.GetSongs();
            var result = songs.Count();
            Assert.AreEqual(expectedCount, result);
        }
    }
}