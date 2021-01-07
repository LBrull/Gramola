using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gramola.Models
{
    public class SearchModel
    {
        public string SearchWord { get; set; }
        public string SearchStyle { get; set; }
    }
}
