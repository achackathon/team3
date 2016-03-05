using AvisaAi.DB;
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
            
            Notification notif = new Notification();

            


            NotificationDB db = new NotificationDB();
            db.Add(notif);
        }
    }
}
