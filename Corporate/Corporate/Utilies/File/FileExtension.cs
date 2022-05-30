using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Corporate.Utilies.File
{
    public static class FileExtension
    {
        public static bool CheckSize(this IFormFile file, int kb)
        {
            if (file.Length / 1024 > kb) return true;
            return false;
        }
        public static bool CheckType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type))
            {
                return true;
            }
            return false;
        }
        public static async Task<string> SaveFileAsync(this IFormFile file, string loc)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(loc, fileName);
            FileStream stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }
        public static void DeleteSlideItem(string imgPath)
        {
            if (System.IO.File.Exists(imgPath))
            {
                System.IO.File.Delete(imgPath);
            }
        }
    }
}
