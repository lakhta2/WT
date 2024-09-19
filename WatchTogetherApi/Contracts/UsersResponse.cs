namespace WatchTogetherApi.Contracts
{
    public record UsersResponse(
        Guid Id,
        string Username,
        string Description,
        decimal Hours
        );
}
