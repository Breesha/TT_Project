using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TT_Project_Model
{
    public class RiderAccountService : IRiderAccountService
    {
        private readonly TT_ProjectContext _context;

        public RiderAccountService(TT_ProjectContext context)
        {
            _context = context;
        }

        public void CreateRiderAccount(RiderAccount rideraccount)
        {
            _context.Add(rideraccount);
            _context.SaveChanges();
        }

        public void UpdateRider()
        {
            _context.SaveChanges();
        }

        public void DeleteRiderAccount(int riderID)
        {
            if (GetRiderAccountByID(riderID) != null)
            {
                var selectedRiderAccount = GetRiderAccountByID(riderID);
                var listEntry = GetRiderEntryByID(riderID);
                var listBike = GetRiderBikeByID(riderID);
                _context.RemoveRange(listBike);
                _context.RemoveRange(listEntry);
                _context.Remove(selectedRiderAccount);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("No ID selected, null");
            }

        }

        public RiderAccount GetRiderAccountByEmail(string riderEmail)
        {
            return _context.RiderAccounts.Where(c => c.Email == riderEmail.Trim()).FirstOrDefault();
        }

        public RiderAccount GetRiderAccountByID(int riderID)
        {
            return _context.RiderAccounts.Where(c => c.RiderId == riderID).FirstOrDefault();
        }

        public List<RiderAccount> GetRiderAccountList()
        {
            return _context.RiderAccounts.ToList();
        }

        public List<Entry> GetRiderEntryByID(int riderID)
        {
            return _context.Entries.Where(c => c.RiderId == riderID).ToList();
        }

        public List<Bike> GetRiderBikeByID(int riderID)
        {
            return _context.Bikes.Where(c => c.RiderId == riderID).ToList();
        }

    }
}
