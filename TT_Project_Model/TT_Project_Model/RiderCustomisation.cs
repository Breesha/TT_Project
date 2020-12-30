using System;
using System.Collections.Generic;
using System.Text;

namespace TT_Project_Model
{
    public partial class RiderAccount
    {
        public override string ToString()
        {
            return $"{RiderId} - {FirstName} {LastName}";
        }
    }
}
