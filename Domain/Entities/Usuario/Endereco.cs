namespace Domain.Entities.Usuario;

public class Endereco
{
    public Guid EnderecoId { get; private set; }
    public string UF { get; private set; }
    public string Cidade { get; private set; }
    public string Bairro { get; private set; }
    public string Cep { get; private set; }
    public string Referencia { get; private set; }
    
    //Cliente
    public virtual Cliente Cliente { get; private set; }
}