﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TT_Project_Model
{
    public partial class Race
    {
        public Race()
        {
            Entries = new HashSet<Entry>();
        }

        public int RaceId { get; set; }
        public string RaceName { get; set; }
        public short NumberOfLaps { get; set; }
        public short NumberOfPitStops { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
