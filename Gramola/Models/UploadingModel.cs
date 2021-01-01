using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramola.Models
{
    public class UploadingModel
    {
        public IFormFile fileSong { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public string path { get; set; }
        public string style { get; set; }
        public string extension { get; set; }
        public string uploader { get; set; }
    }
}
