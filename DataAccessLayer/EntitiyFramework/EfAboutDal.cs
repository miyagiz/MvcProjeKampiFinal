using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using DataAccessLayer.Concreate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EfAboutDal : Concreate.Repositories.GenericRepository<About>,IAboutDal
    {
    }
}
