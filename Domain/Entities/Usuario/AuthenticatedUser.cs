namespace KitandaAPI.Services.Authentication;

public static class AuthenticatedUser
{
    public static Guid UserId { get; set; }

    public static Guid ObterUsuarioLogado()
    {
        return UserId;
    }
}