using Models.Business;
using Models.Mapper.Request;
using Models.Mapper.Response;

namespace Business.Interface
{
    public interface IUserService
    {
        User Create(User inputModel);
        User GetById(int Id);
        User Update(User entity);
        Task<LoginResponse> Login(LoginPost request);
    }
}
