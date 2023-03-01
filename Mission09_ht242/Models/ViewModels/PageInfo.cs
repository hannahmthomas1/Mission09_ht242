﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_ht242.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumProjects { get; set; }
        public int ProjectsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Figure out how many pages we need
        public int Totalpages => (int) Math.Ceiling((double) TotalNumProjects / ProjectsPerPage);
    }
}
