using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Helper.FileManager
{
    public static class FileManager
    {
        public static byte[] GetBytes(string path)
        {
            byte[] fileArray = File.ReadAllBytes(path);

            return fileArray;
        }

        public static string LoadFileToBase64(string path)
        {            
            byte[] imageArray = GetBytes(path);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return base64ImageRepresentation;
        }

        public static string Base64ToFileBase64(string data, string type)
        {
            string fileBase64 = $"data:{type};base64,{data}";
            return fileBase64;
        }

        public static void SaveFile(string path,string base64)
        {
            var bytes = Convert.FromBase64String(base64);            

            using (var ms = new MemoryStream(bytes))
            {
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    ms.WriteTo(fs);
                }
            }
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

    }
}
