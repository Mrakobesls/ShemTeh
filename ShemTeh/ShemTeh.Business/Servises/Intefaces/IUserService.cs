using ShemTeh.Business.Models;

namespace ShemTeh.Business.Servises
{
    public interface IUserService : IGenericService<UserDto>
    {
        UserDto Authenticate(string login, string password);
        bool PersonExists(string login);
        UserDto ReadByLogin(string login);
    }
}
