using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin AdminUsernameAndPass(string username, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == username && x.AdminPassword == password && x.AdminStatus == true);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List(x => x.AdminStatus == true);
        }

        public List<Admin> GetListStatusFalse()
        {
            return _adminDal.List(x => x.AdminStatus == false);
        }
    }
}
