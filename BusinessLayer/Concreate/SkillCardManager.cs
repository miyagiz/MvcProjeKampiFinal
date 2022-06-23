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
    public class SkillCardManager : ISkillCardService
    {
        ISkillCardDal _skillCardDal;

        public SkillCardManager(ISkillCardDal skillCardDal)
        {
            _skillCardDal = skillCardDal;
        }

        public void AddSkillCard(SkillCard skillCard)
        {
            _skillCardDal.Insert(skillCard);
        }

        public void DeleteSkillCard(SkillCard skillCard)
        {
            _skillCardDal.Delete(skillCard);
        }

        public SkillCard GetByID(int id)
        {
            return _skillCardDal.Get(x => x.SkillCardID == id);
        }

        public List<SkillCard> GetList()
        {
            return _skillCardDal.List();
        }

        public void UpdateSkillCard(SkillCard skillCard)
        {
            _skillCardDal.Update(skillCard);
        }
    }
}
