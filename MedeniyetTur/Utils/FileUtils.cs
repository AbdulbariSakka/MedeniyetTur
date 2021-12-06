using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MedeniyetTur.Utils
{
    public class FileUtils
    {
        public static string StoreImage(IFormFile file, string path)
        {
            string filePath = Path.Combine(path, "Data");
            string filename = Path.GetFileName(file.FileName);
            var formattedFileName = string.Format("{0}-{1}{2}"
                        , Path.GetFileNameWithoutExtension(filename)
                        , Guid.NewGuid().ToString("N")
                        , Path.GetExtension(filename));
            using (Stream fileStream = new FileStream(Path.Combine(filePath, formattedFileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return formattedFileName;
        }
    }
}
