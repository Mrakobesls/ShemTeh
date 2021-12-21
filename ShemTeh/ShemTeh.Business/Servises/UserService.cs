using ShemTeh.Business.Hashing;
using ShemTeh.Business.Models;
using ShemTeh.Data.Models;
using ShemTeh.Data.UnitOfWork;

namespace ShemTeh.Business.Servises
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IPasswordCrypt _crypt;

        public UserService(IUnitOfWork userRepository, IPasswordCrypt crypt)
        {
            _uow = userRepository;
            _crypt = crypt;
        }

        public int Add(UserDto entity)
        {
            var existingUser = _uow.Users
                .ReadAll()
                .FirstOrDefault(u => u.Login == entity.Login);

            if (existingUser is not null)
            {
                if (existingUser.Login == entity.Login)
                {
                    throw new ArgumentException("There's already exists a user with this login");
                }
            }

            entity.Password = _crypt.HashPassword(entity.Password);
            User entityDb = entity;
            _uow.Users.Create(entityDb);

            _uow.SaveChanges();

            return entityDb.Id;
        }

        public UserDto Authenticate(string login, string password)
        {
            var user = _uow.Users.ReadAll().FirstOrDefault(u => u.Login == login);
            if (user is null)
                return null;

            return _crypt.Verify(password, user.Password)
                ? user
                : null;
        }

        public bool PersonExists(string login)
        {
            return _uow.Users.ReadAll().FirstOrDefault(p => p.Login == login) is { };
        }

        public UserDto ReadByLogin(string login)
        {
            return _uow.Users.ReadAll().FirstOrDefault(p => p.Login == login);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto Read(int id)
        {
            return _uow.Users.Read(id);
        }

        public List<UserDto> ReadAll()
        {
            return _uow.Users.ReadAll().Select(u => (UserDto)u).ToList();
        }

        public void Update(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
