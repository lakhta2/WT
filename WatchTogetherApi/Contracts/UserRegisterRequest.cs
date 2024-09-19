namespace WatchTogetherApi.Contracts
{
    public record UserRegisterRequest(
         string Username,
         string Email,
         string Password
         );
}
