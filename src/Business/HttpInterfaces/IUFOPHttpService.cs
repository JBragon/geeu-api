using Models.Mapper.Request;
using Models.Mapper.Response;
using Refit;

namespace Business.HttpInterfaces
{
    public interface IUFOPHttpService
    {
        [Post("/auth")]
        Task<UFOPLoginResponse> Login([Body] LoginPost request, [Authorize("Basic")] string token);
    }
}
