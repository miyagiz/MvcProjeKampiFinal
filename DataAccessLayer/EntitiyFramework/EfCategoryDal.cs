using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repositories;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EfCategoryDal : Concreate.Repositories.GenericRepository<Category>,ICategoryDal
    {

    }
}
