using Ecom.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Core.ServiceImplementation
{
    public class ImageMangmentService : IImageMangmentService
    {
        private readonly IFileProvider _fileProvider;

        public ImageMangmentService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        public void DeleteImageAsync(string src)
        {
            var info = _fileProvider.GetFileInfo(src);
            if (info.Exists)
            {
                File.Delete(info.PhysicalPath);
            }
        }

        public async Task<List<string>> UploadImagesAsync(IFormFileCollection files, string src)
        {
           var savedImageSrc = new List<string>();
            var ImageDirectory = Path.Combine("wwwroot", "Images" ,src);
            if(!Directory.Exists(ImageDirectory))
            {
                Directory.CreateDirectory(ImageDirectory);
            }

            foreach (var file in files)
            {
                if(file.Length > 0)
                {
                    
                    var imageScr = $"/Images/{src}/{file.FileName}";
                    var root = Path.Combine(ImageDirectory, file.FileName);
                    using (var stream = new FileStream(root, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    savedImageSrc.Add(imageScr);
                }
                
            }
            return savedImageSrc;
        }
    }
}
