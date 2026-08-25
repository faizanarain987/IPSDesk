namespace IPSDesk.Services;

public interface ICurrentUserService
{
    string? UserId { get; set; }
    string? UserName { get; set; }
}

public class CurrentUserService : ICurrentUserService
{
    public string? UserId { get; set; }
    public string? UserName { get; set; }
}
