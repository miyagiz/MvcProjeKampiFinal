﻿using DataAccessLayer.Abstract;
using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EfSkillCardDal : Concreate.Repositories.GenericRepository<SkillCard>, ISkillCardDal
    {
    }
}
