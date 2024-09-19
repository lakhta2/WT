using System.ComponentModel.DataAnnotations;

namespace WatchTogetherApi.Contracts
{
    public record TLoginRequest(
        [Required] string Email,
        [Required] string Password
         );
}
