namespace AvisaAi.Data.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool ReceiveEmail { get; set; }
    }
}
