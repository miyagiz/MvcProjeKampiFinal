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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public ImageFile GetById(int id)
        {
            return _imageFileDal.Get(x => x.ImageID == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void ImageAdd(ImageFile ımageFile)
        {
            _imageFileDal.Insert(ımageFile);
        }

        public void ImageDelete(ImageFile ımageFile)
        {
            _imageFileDal.Delete(ımageFile);
        }

        public void ImageUpdate(ImageFile ımageFile)
        {
            _imageFileDal.Update(ımageFile);
        }
    }
}
