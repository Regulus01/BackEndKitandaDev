﻿namespace Domain.Data.ViewModels.Criacao;

public class ClienteViewModel
{
    public Guid ClienteId { get; set; }
    public string NomeCliente { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    
    public UsuarioViewModel Usuario { get; set; }
}