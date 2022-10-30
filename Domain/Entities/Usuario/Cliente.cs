namespace Domain.Entities.Usuario;

public class Cliente
{
    public Guid ClienteId { get; set; }
    public string NomeCliente { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    
    //public Guid IdCategoria { get; private set; }
    //public virtual CategoriaProduto Categoria { get; private set; }
    
    //Usuario
    public Guid UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }

}