using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetList();
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeadingId(int id);
        Content GetById(int id);
        void ContentAdd(Content content);
        void ContentUpdate(Content content);
        void ContentDelete(Content content);
        
    }
}
