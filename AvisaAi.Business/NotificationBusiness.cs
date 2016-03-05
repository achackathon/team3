using AvisaAi.Data.Entities;
using AvisaAi.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public List<Notification> GetByNotificationType(int NotificationTypeId)
        {
            var notifications = Get();
            var result = from n in notifications
                         where n.NotificationTypeId == NotificationTypeId
                         select n;

            return result.ToList();
        }

        public List<Notification> Get(double Latitude, double Longitude)
        {
            return repo.Get(Latitude, Longitude);
        }

        public List<Notification> Get(double Latitude, double Longitude, int NotificationTypeId)
        {
            var notifications = Get(Latitude, Longitude);
            var result = from n in notifications
                         where n.NotificationTypeId == NotificationTypeId
                         select n;

            return result.ToList();
        }
    }
}
