using System;

namespace AvisaAi.Data.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Name { get; set; }
        public int LocalId { get; set; }
        public NotificationUser NotificationUser { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
