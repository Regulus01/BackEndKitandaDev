namespace Domain.Entities.Usuario
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Criacao {get; set;}
    }
}
