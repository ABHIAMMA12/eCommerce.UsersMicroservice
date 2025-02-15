namespace UsersMicroservice.Core.DTO
{
    public record LoginRequest(
       string? Email,
       string? Password);

}
