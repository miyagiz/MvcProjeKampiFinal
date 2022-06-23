using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EfAdminDal : Concreate.Repositories.GenericRepository<Admin>, IAdminDal
    {
    }
}
