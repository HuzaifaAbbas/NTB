using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTB.Models
{
    public class Pagination
    {
        public List<Land> Lands { get; set; }

        public int CurrentPage { get; set; }

        public int TotalLands { get; set; }

        public int PageSize { get; set; }

    }
}