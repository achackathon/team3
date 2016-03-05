using AvisaAi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvisaAi.Interfaces
{
    public abstract class INotificationRepository
    {
        public abstract bool Add(Notification notification);
        public abstract List<Notification> Get();
        public abstract List<Notification> Get(double Latitude, double Longitude);
    }
}
