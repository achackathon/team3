using AvisaAi.Data.Entities;
using AvisaAi.WebApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System;

namespace AvisaAi.WebApi.Controllers
{
    public class NotificationController : ApiController
    {
        // GET: api/Notification
        public List<NotificationModel> Get()
        {
            var notifications = (new Business.NotificationBusiness(new DB.NotificationDB())).Get();
            return SeedNotification(notifications);
        }

        private List<NotificationModel> SeedNotification(List<Notification> notifications)
        {
            var userRepo = new Business.UserBusiness(new DB.UserDB());
            var notificationTypeRepo = new Business.NotificationTypeBusiness();

            var result = new List<NotificationModel>();

            foreach (Notification n in notifications)
            {
                result.Add(new NotificationModel
                {
                    Id = n.Id,
                    Name = n.Name,
                    Description = n.Description,
                    Latitude = n.Latitude,
                    Longitude = n.Longitude,
                    DateAdded = n.DateAdded,
                    ExpiresOn = n.ExpiresOn,
                    User = userRepo.Get(n.Id),
                    NotificationType = notificationTypeRepo.GetById(n.NotificationTypeId)
                });
            }
            return result;
        }

        // GET: api/Notification
        public List<NotificationModel> GetNearby(double Latitude, double Longitude)
        {
            var notifications = new Business.NotificationBusiness(new DB.NotificationDB());
            //return notif.GetNearby(Latitude, Longitude);
            return SeedNotification(notifications.GetNearby(Latitude, Longitude));
        }

        // GET: api/Notification/5
        public Notification Get(int id)
        {
            var notif = new Business.NotificationBusiness(new DB.NotificationDB());
            var filter = from r in notif.Get()
                         where r.Id == id
                          select r;

            return filter.FirstOrDefault();
        }

        // POST: api/Notification
        public bool Post(Notification value)
        {
            var notif = new Business.NotificationBusiness(new DB.NotificationDB());
            return notif.Add(value);
        }

        // PUT: api/Notification/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/Notification/5
        public void Delete(int id)
        {
        }
    }
}
