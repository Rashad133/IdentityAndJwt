namespace JWT.Api.DTOs
{
    public sealed record LoginDTO(string UsernameOrEmail,string Password);
}
