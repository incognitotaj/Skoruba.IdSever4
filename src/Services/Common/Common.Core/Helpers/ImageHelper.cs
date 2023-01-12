using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Helpers
{
    public class ImageHelper
    {
        private readonly IWebHostEnvironment _environment;

        public ImageHelper(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SavePostImageAsync(IFormFile file)
        {

            var uniqueFileName = FileHelper.GetUniqueFileName(file.FileName);

            var uploads = Path.Combine(_environment.WebRootPath, "images", "products", Guid.NewGuid().ToString());

            var filePath = Path.Combine(uploads, uniqueFileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));

            return filePath;
        }

    }
}
