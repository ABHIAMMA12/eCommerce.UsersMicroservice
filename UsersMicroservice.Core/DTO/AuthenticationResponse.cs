namespace UsersMicroservice.Core.DTO
{
    public record AuthenticationResponse(
        Guid UserId,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success)
    {
        //Assigns the default values calls the parameter constructor
        public AuthenticationResponse() : this(default, default, default, default, default, default)
        {

        }
    }
}
