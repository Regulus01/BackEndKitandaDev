namespace Domain.Entities.Usuario;

public class Cliente
{
    public Guid ClienteId { get; private set; }
    public string NomeCliente { get; private set; }
    public string Telefone { get; private set; }
    public string Cpf { get; private set; }
    
    //Endereco
    public Guid EnderecoId { get; private set; }
    public virtual Endereco Endereco { get; private set; }
    
    //Usuario
    public Guid UsuarioId { get; private set; }
    public virtual Usuario Usuario { get; private set; }
    

    public void InformeUsuarioId(Guid usuarioId)
    {
        UsuarioId = usuarioId;
    }
    

}