using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramola.Models
{
    public class Song
    {
        private enum Styles
        {
            Pop,
            Rock,
            HardRock,
            Rap,
            Reggaeton,
            Classic,
            Disco,
            Reggae,
            Other,
            Unknown
        }

        public int id { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public string extension { get; set; }
        public string path { get; set; }
        public string style { get; private set; }
        public string uploader { get; set; }

        public void SetStyle(string style)
        {
            if (style == "Pop")
                this.style = Styles.Pop.ToString();

            else if (style == "Rock")
                this.style = Styles.Rock.ToString();

            else if (style == "HardRock")
                this.style = Styles.HardRock.ToString();

            else if (style == "Rap")
                this.style = Styles.Rap.ToString();

            else if (style == "Reggaeton")
                this.style = Styles.Reggaeton.ToString();

            else if (style == "Classic")
                this.style = Styles.Classic.ToString();

            else if (style == "Disco")
                this.style = Styles.Disco.ToString();

            else if (style == "Reggae")
                this.style = Styles.Reggae.ToString();

            else if (style == "Other")
                this.style = Styles.Other.ToString();

            else
            {
                this.style = Styles.Unknown.ToString();
            }
        }
    }
}
