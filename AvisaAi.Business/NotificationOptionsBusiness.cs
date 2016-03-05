using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvisaAi.Data.Entities;
using AvisaAi.DB;

namespace AvisaAi.Business
{
    public class NotificationOptionsBusiness
    {
        public List<NotificationOption> GetByNotificationType(int notificationTypeID) {

            return new NotificationOptionDB().GetNotificationOptionsByNotificationType(notificationTypeID);

        }
    }
}
