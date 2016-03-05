using AvisaAi.Data.Entities;
using AvisaAi.DB;
using System;
using System.Collections.Generic;

namespace AvisaAi.Business
{
    public class NotificationTypeBusiness
    {
        #region [Region]

        public IEnumerable<NotificationType> Get()
        {
            return new NotificationTypeDB().GetAll();
        }

        public IEnumerable<NotificationType> GetByUserId(int id)
        {
            return new NotificationTypeDB().GetByUserId(id);
        }

        public NotificationType GetById(int id)
        {
            return new NotificationTypeDB().GetById(id);
        }

        #endregion
    }
}
