using ShemTeh.Business.Models;
using ShemTeh.Data.Models;
using ShemTeh.Data.UnitOfWork;

namespace ShemTeh.Business.Servises
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork _uow;
        public RoleService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }


        public int Add(RoleDto entity)
        {
            Role entityDb = entity;
            _uow.Roles.Create(entityDb);

            _uow.SaveChanges();

            return entityDb.Id;
        }

        public RoleDto Read(int id)
        {
            return _uow.Roles.Read(id);
        }

        public List<RoleDto> ReadAll()
        {
            return _uow.Roles.ReadAll()
                .Select(c => (RoleDto)c).ToList();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleDto entity)
        {
            _uow.Roles.Update(entity);

            _uow.SaveChanges();
        }
    }
}
