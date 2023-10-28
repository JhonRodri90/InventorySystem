using DataTransferObjects.Dto;
using DataTransferObjets.Configuration;
using DataTransferObjets.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AbstractLogic.Product
{
    internal static class ProductLogic
    {
        public static void CreateDirectoryImages(string fullPath)
        {
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
        }
        public static void EraseToRewrite(string pathUpload)
        {
            if (File.Exists(pathUpload))
                File.Delete(pathUpload);
        }

        public static ResponseImagesDto SavePicture(ImagesDto images)
        {
            string upload = images.UpLoadPath;
            string fileName = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(images.Files[0].FileName);
            string fileFullPath = Path.Combine(upload, fileName) + extension;

            using (var fileStream = new FileStream(fileFullPath, FileMode.Create))
                images.Files[0].CopyTo(fileStream);

            return new ResponseImagesDto
            {
                SavePath = StaticDefination.ImagePath + fileName + extension,
                RequestResponse = true
            };
        }
    }
}