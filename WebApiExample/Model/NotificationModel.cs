using AvisaAi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisaAi.WebApi.Model
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual User User { get; set; }
        public DateTime ExpiresOn { get; set; }
        public virtual NotificationType NotificationType { get; set; }

    }
}