using System;
using System.Collections.Generic;
using System.Text;

namespace TT_Project_Model
{
    public partial class Bike
    {
        public override string ToString()
        {
            return $"MAKE: {BikeMake} - SPONSOR: {BikeSponsor}" ;
        }
    }
}
