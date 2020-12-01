using System;
using System.Collections.Generic;

#nullable disable

namespace TT_Project_Model
{
    public partial class Bike
    {
        public int BikeId { get; set; }
        public string BikeMake { get; set; }
        public string BikeSponsor { get; set; }
        public int? RiderId { get; set; }

        public virtual RiderAccount Rider { get; set; }
    }
}
