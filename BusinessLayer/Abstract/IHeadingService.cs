using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        List<Heading> GetListByWriterInactive(int id);

        void HeadingAdd(Heading heading);
        Heading GetById(int id);
        void HeadingUpdate(Heading heading);
        void HeadingDelete(Heading heading);
    }
}
