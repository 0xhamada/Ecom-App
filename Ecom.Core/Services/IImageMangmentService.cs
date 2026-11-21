using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Core.Services
{
    public interface IImageMangmentService
    {
        Task<List<string>> UploadImagesAsync(IFormFileCollection collection , string src);
        void DeleteImageAsync(string src);
    }
}
