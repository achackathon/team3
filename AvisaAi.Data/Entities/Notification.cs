using System;

namespace AvisaAi.Data.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserID { get; set; }
        public DateTime ExpiresOn { get; set; }
        public int NotificationTypeId { get; set; }

    }
}
