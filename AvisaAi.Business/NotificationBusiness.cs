using AvisaAi.Data.Entities;
using AvisaAi.Interfaces;
using System.Collections.Generic;

namespace AvisaAi.Business
{
    public class NotificationBusiness
    {
        private INotificationRepository repo;
        public NotificationBusiness(INotificationRepository repo)
        {
            this.repo = repo;
        }
        public bool Add(Notification notification)
        {
            return repo.Add(notification);
        }

        public List<Notification> Get()
        {
            return repo.Get();
        }

        public List<Notification> GetNearby(double Latitude, double Longitude)
        {
            return repo.GetNearby(Latitude, Longitude);
        }

    }
}
