using System;
using System.Collections.Generic;
using System.Text;

namespace TT_Project_Model
{
    public partial class Entry
    {
        public override string ToString()
        {
            string message = "";
            if (RaceId == 1)
            {
                message = "Supersport"
            }
            if (RaceId == 2)
            {
                message = "Superstock"
            }
            if (RaceId == 3)
            {
                message = "Lightweight"
            }
            if (RaceId == 4)
            {
                message = "TT Zero"
            }
            if (RaceId == 5)
            {
                message = "SENIOR - Superbike"
            }
            return $"{RaceId} - {message}";
        }
    }
}