using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        Admin GetById(int id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        void AdminAdd(Admin admin);
        Admin AdminUsernameAndPass(string username, string password);
    }
}
