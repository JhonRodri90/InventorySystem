using AutoMapper;
using DataTransferObjects.Dto;
using DataTransferObjets.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.AbstractLogic.Product
{
    internal static class ProductLogic
    {
        public static void CreateDirectoryImages(string fullpath)
        {
            if(!Directory.Exists(fullpath))
                Directory.CreateDirectory(fullpath);
        }

        public static void EraseToReWrite(string pathLoad)
        {
            if (File.Exists(pathLoad))
                File.Delete(pathLoad);
        }

        public static ResponseImagesDto SavePicture(ImagesDto images)
        {
            string upLoad = images.UpLoadPath;
            string fileName = Guid.NewGuid().ToString();    
            string extension = Path.GetExtension(images.Files[0].FileName);
            string fileFullPath = Path.Combine(upLoad, fileName) + extension;

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
