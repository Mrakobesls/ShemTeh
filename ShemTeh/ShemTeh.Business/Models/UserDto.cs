using ShemTeh.Data.Models;

namespace ShemTeh.Business.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Group { get; set; }
        public int RoleId { get; set; }

        public static implicit operator UserDto(User user)
        {
            return user is null
                ? null
                : new UserDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Password = user.Password,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Group = user.Group,
                    RoleId = user.RoleId
                };
        }


        public static implicit operator User(UserDto userDto)
        {
            return userDto is null
                ? null
                : new User
                {
                    Id = userDto.Id,
                    Login = userDto.Login,
                    Password = userDto.Password,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Group = userDto.Group,
                    RoleId = userDto.RoleId
                };
        }
    }
}
