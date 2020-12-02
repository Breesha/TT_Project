using System;
using System.Collections.Generic;

#nullable disable

namespace TT_Project_Model
{
    public partial class RiderRace
    {
        public int EntryId { get; set; }
        public int? RiderId { get; set; }
        public int? RaceId { get; set; }

        public virtual Race Race { get; set; }
        public virtual RiderAccount Rider { get; set; }
    }
}
