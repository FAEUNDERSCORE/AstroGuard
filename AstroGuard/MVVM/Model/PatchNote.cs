﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroGuard.MVVM.Model
{
    public class PatchNote
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
