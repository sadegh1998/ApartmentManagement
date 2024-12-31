using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace Modirsa.Mobile
{
    public class FileUploader : IFileUploader
    {
       
        public string Upload(IFormFile file, string path)
        {
            
            if (file == null) return "";

            var directoryPath = $"{Path.Combine(FileSystem.Current.AppDataDirectory, "WebAppFolder")}//ProductPictures//{path}";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var fileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var filePath = $"{directoryPath}//{fileName}";
            using var output =  File.Create(filePath);
            file.CopyTo(output);
            return $"{path}/{fileName}";
        }
    }
}
