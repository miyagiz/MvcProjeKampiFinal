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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List(x => x.HeadingStatus == true);
        }

        public List<Heading> GetListInactiveHeading()
        {
            return _headingDal.List(x => x.HeadingStatus == false);
        }

        public List<Heading> GetListByCategories(int id)
        {
            return _headingDal.List(x => x.CategoryID == id);
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id && x.HeadingStatus == true);
        }



        public void HeadingAdd(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetListByWriterInactive(int id)
        {
            return _headingDal.List(x => x.WriterID == id && x.HeadingStatus == false);
        }
    }
}

//DERS 56 BAŞLANMADI
