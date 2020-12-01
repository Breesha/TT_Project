using System;
using System.Collections.Generic;

#nullable disable

namespace TT_Project_Model
{
    public partial class staff
    {
        public int? StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual StaffAccount Staff { get; set; }
    }
}
