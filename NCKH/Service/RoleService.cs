using NCKH.Datta;
using NCKH.Models;

namespace NCKH.Service
{
    public class RoleService
    {
        private readonly ApplicationDbContext _context;
        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }
        public void AddRoles(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }
        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(p => p.Id == id);
        }
        public void UpdateEmployee(Role Role)
        {
            _context.Roles.Update(Role);
            _context.SaveChanges();
        }
        public void DeleteRole(int id)
        {
            var employRole = _context.Roles.Find(id);
            if (employRole != null)
            {
                _context.Roles.Remove(employRole);
                _context.SaveChanges();
            }

        }
    }
}