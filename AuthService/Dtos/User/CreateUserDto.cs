namespace AuthService.Dtos.User
{
    public record CreateUserDto(
        string Email,
        string Password,
        string SteamProfileName     // this will be obtained via token once steam integration is done
    );
}
