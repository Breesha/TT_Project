﻿using System;
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
                var newRace1 = new Race
                {
                    RaceName = "Superstock",
                    NumberOfLaps = 4,
                    NumberOfPitStops = 1
                };
                db.Races.Add(newRace1);
                db.SaveChanges();

                var newRace2 = new Race
                {
                    RaceName = "Supersport",
                    NumberOfLaps = 4,
                    NumberOfPitStops = 1
                };
                db.Races.Add(newRace2);
                db.SaveChanges();

                var newRace3 = new Race
                {
                    RaceName = "Lightweight",
                    NumberOfLaps = 4,
                    NumberOfPitStops = 1
                };
                db.Races.Add(newRace3);
                db.SaveChanges();

                var newRace4 = new Race
                {
                    RaceName = "TT Zero",
                    NumberOfLaps = 1,
                    NumberOfPitStops = 0
                };
                db.Races.Add(newRace4);
                db.SaveChanges();

                var newRace5 = new Race
                {
                    RaceName = "SENIOR - Superbike",
                    NumberOfLaps = 6,
                    NumberOfPitStops = 2
                };
                db.Races.Add(newRace5);
                db.SaveChanges();
            }
        }
    }
}
