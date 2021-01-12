using System;
using System.Collections.Generic;
using System.Text;

namespace TT_Project_Model
{
    public interface IRiderAccountService
    {
        void CreateRiderAccount(RiderAccount rideraccount);
        void UpdateRider();
        void DeleteRiderAccount(int riderID);
        RiderAccount GetRiderAccountByEmail(string riderEmail);
        RiderAccount GetRiderAccountByID(int riderID);
        List<RiderAccount> GetRiderAccountList();
        List<Bike> GetRiderBikeByID(int riderID);
        List<Entry> GetRiderEntryByID(int riderID);
        
    }
}
