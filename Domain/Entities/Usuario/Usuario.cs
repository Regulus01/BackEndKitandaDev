namespace Domain.Entities.Usuario
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public DateTime Criacao {get; private set;}
        
        public virtual Cliente Cliente { get; set; }

        public void InformeRole(string role)
        {
            Role = role;
        }

        public void InformeSennha(string senha)
        {
            Password = senha;
        }

        public void InfomeCriacao(DateTime criacao)
        {
            Criacao = criacao;
        }
    }
}
