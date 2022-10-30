namespace Domain.Entities.Usuario;

public class Endereco
{
    public Guid EnderecoId { get; set; }
    public string Bairro { get; set; }
    public string Cep { get; set; }
    public string Referencia { get; set; }
}