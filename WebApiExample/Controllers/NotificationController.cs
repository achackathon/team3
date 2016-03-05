using AvisaAi.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AvisaAi.WebApi.Controllers
{
    public class NotificationController : ApiController
    {
        // GET: api/Notification
        public List<Notification> Get()
        {
            var notif = new Business.NotificationBusiness(new DB.NotificationDB());
            return notif.Get();
        }

        // GET: api/Notification
        public List<Notification> GetNearby(double Latitude, double Longitude)
        {
            var notif = new Business.NotificationBusiness(new DB.NotificationDB());
            return notif.GetNearby(Latitude, Longitude);
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
