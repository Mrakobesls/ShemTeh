using ShemTeh.Data.Models;

namespace ShemTeh.Business.Models
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator RoleDto(Role role)
        {
            return role is null
                ? null
                : new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name
                };
        }


        public static implicit operator Role(RoleDto roleDto)
        {
            return roleDto is null
                ? null
                : new Role
                {
                    Id = roleDto.Id,
                    Name = roleDto.Name
                };
        }
    }
}
