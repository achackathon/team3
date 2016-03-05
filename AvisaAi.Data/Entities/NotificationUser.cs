namespace AvisaAi.Data.Entities
{
    public class NotificationUser
    {
        public int NotificationUserId { get; set; }
        public User User { get; set; }
        public Notification Notification { get; set; }
    }
}
