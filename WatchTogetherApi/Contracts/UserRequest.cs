namespace WatchTogetherApi.Contracts
{
    public record UserRequest(
        string Username,
        string Description,
        decimal Hours

        );
}
