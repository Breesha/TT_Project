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
            Entries = new HashSet<Entry>();
        }

        public int RiderId { get; set; }
        public string Email { get; set; }
        public string Passwrd { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Experience { get; set; }

        public virtual ICollection<Bike> Bikes { get; set; }
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
