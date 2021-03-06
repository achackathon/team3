﻿using AvisaAi.DB;
using AvisaAi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGetNearBy(-19.936220, -43.935169);
        }

        static void TestAdd()
        {
            Notification notif = new Notification();

            notif.Name = "First One!";
            notif.Latitude = -19.936220;
            notif.Longitude = -43.935169;
            notif.Description = "Test notifiation";
            notif.DateAdded = DateTime.Now;
            notif.UserID = 2;
            notif.ExpiresOn = DateTime.Now.AddDays(1);
            notif.NotificationTypeId = 1;

            NotificationDB db = new NotificationDB();
            db.Add(notif);
        }

        static void TestGet()
        {
            NotificationDB db = new NotificationDB();
            var list = db.Get();
        }

        static void TestGetNearBy(double Latitude, double Longitude)
        {
            NotificationDB db = new NotificationDB();
            var list = db.Get(Latitude, Longitude);
        }
    }
}
