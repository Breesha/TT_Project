using System;
using System.Collections.Generic;

#nullable disable

namespace TT_Project_Model
{
    public partial class RiderAccount
    {
        public RiderAccount()
        {
            Bikes = new HashSet<Bike>();
        }

        public int RiderId { get; set; }
        public string Email { get; set; }
        public string Passwrd { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
    }
}
