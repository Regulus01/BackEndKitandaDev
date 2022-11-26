namespace Domain.Entities.Usuario;

public class Cliente
{
    public Guid ClienteId { get; private set; }
    public string NomeCliente { get; private set; }
    public string Telefone { get; private set; }
    public string Cpf { get; private set; }
    
    //Endereco
    public string UF { get; private set; }
    public string Cidade { get; private set; }
    public string Bairro { get; private set; }
    public string Cep { get; private set; }
    public string Referencia { get; private set; }
    
    //Usuario
    public Guid UsuarioId { get; private set; }
    public virtual Usuario Usuario { get; private set; }
    

    public virtual List<Produto> Produtos { get; } 
    
    public void InformeUsuarioId(Guid usuarioId)
    {
        UsuarioId = usuarioId;
    }

    public void ComprarProduto(Produto produto)
    {
        Produtos.Add(produto);
    }
    

}