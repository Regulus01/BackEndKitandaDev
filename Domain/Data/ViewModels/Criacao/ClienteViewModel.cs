namespace Domain.Data.ViewModels.Criacao;

public class ClienteViewModel
{
    public string NomeCliente { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }

    //Endereco
    public string UF { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public string Cep { get; set; }
    public string Referencia { get; set; }
    public UsuarioViewModel Usuario { get; set; }
}