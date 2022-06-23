using EntitiyLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        ImageFile GetById(int id);
        void ImageAdd(ImageFile ımageFile);
        void ImageUpdate(ImageFile ımageFile);
        void ImageDelete(ImageFile ımageFile);
    }
}
