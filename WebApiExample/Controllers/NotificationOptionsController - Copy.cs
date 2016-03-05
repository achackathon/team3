using AvisaAi.Business;
using AvisaAi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AvisaAi.WebApi.Controllers
{
    public class NotificationOptionsController : ApiController
    {
        // GET: api/NotificationOptions
        public List<NotificationOption> Get(int notificationTypeId)
        {
            var notifications = (new DB.NotificationOptionDB().GetNotificationOptionsByNotificationType(notificationTypeId));
            return notifications;
        }
    }
}
