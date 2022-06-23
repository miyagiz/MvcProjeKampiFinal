using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillCardService
    {
        List<SkillCard> GetList();
        SkillCard GetByID(int id);
        void UpdateSkillCard(SkillCard skillCard);
        void DeleteSkillCard(SkillCard skillCard);
        void AddSkillCard(SkillCard skillCard);
    }
}
