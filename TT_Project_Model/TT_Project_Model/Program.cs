using System;
using System.Linq;
using System.Collections.Generic;

namespace TT_Project_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TT_ProjectContext())
            {
                //var newRace1 = new Race
                //{
                //    RaceName = "Superstock",
                //    NumberOfLaps = 4,
                //    NumberOfPitStops = 1
                //};
                //db.Races.Add(newRace1);
                //db.SaveChanges();

                //var newRace2 = new Race
                //{
                //    RaceName = "Supersport",
                //    NumberOfLaps = 4,
                //    NumberOfPitStops = 1
                //};
                //db.Races.Add(newRace2);
                //db.SaveChanges();

                //var newRace3 = new Race
                //{
                //    RaceName = "Lightweight",
                //    NumberOfLaps = 4,
                //    NumberOfPitStops = 1
                //};
                //db.Races.Add(newRace3);
                //db.SaveChanges();

                //var newRace4 = new Race
                //{
                //    RaceName = "TT Zero",
                //    NumberOfLaps = 1,
                //    NumberOfPitStops = 0
                //};
                //db.Races.Add(newRace4);
                //db.SaveChanges();

                //var newRace5 = new Race
                //{
                //    RaceName = "SENIOR - Superbike",
                //    NumberOfLaps = 6,
                //    NumberOfPitStops = 2
                //};
                //db.Races.Add(newRace5);
                //db.SaveChanges();

                //var newRider = new RiderAccount
                //{
                //    Email = "breeshafoxton@hotmail.com",
                //    Passwrd = "password",
                //    FirstName = "Breesha",
                //    LastName = "Foxton",
                //    DateOfBirth = "24/06/1998",
                //    Nationality = "Manx",
                //    Experience = "no rider experience"
                //};
                //db.RiderAccounts.Add(newRider);
                //db.SaveChanges();

                //var newBike = new Bike
                //{
                //    RiderId = 1,
                //    BikeMake = "Norton",
                //    BikeSponsor = "Norton"
                //};
                //db.Bikes.Add(newBike);
                //db.SaveChanges();

                //var newEntry = new Entry
                //{
                //    RiderId = 1,
                //    RaceId = 1
                //};
                //db.Entries.Add(newEntry);
                //db.SaveChanges();

                //var newRider = new RiderAccount
                //{
                //    Email = "deanharrison@hotmail.com",
                //    Passwrd = "password2",
                //    FirstName = "Dean",
                //    LastName = "Harrison",
                //    DateOfBirth = "01/05/1985",
                //    Nationality = "English",
                //    Experience = "SENIOR - Superbike winner 2019"
                //};
                //db.RiderAccounts.Add(newRider);
                //db.SaveChanges();

                //var newRider2 = new RiderAccount
                //{
                //    Email = "michaeldunlop@hotmail.com",
                //    Passwrd = "password3",
                //    FirstName = "Michael",
                //    LastName = "Dunlop",
                //    DateOfBirth = "01/06/1985",
                //    Nationality = "Irish",
                //    Experience = "SENIOR - Superbike winner 2018"
                //};
                //db.RiderAccounts.Add(newRider2);
                //db.SaveChanges();

                //var newRider3 = new RiderAccount
                //{
                //    Email = "peterhickman@hotmail.com",
                //    Passwrd = "password4",
                //    FirstName = "Peter",
                //    LastName = "Hickman",
                //    DateOfBirth = "01/07/1980",
                //    Nationality = "English",
                //    Experience = "SENIOR - Superbike second place 2019, Supersport winner 2019"
                //};
                //db.RiderAccounts.Add(newRider3);
                //db.SaveChanges();

                //var deleteRider =
                //from ra in db.RiderAccounts
                //where ra.RiderId == 21
                //select ra;
                //db.RiderAccounts.RemoveRange(deleteRider);
                //db.SaveChanges();
            }
        }
    }
}
