using Core.Interfaces;
using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Core.Helpers
{
    public class FileWriter : IFileWriter
    {
        public string _filePath;

        public FileWriter(IConfiguration configuration, IHostingEnvironment env)
        {
            var directoryPath = env.ContentRootPath;
            var folderName = configuration["SortingResultFolderName"];
            if (folderName == null)
                throw new NullReferenceException("SortingResultFolderName variable not specified in appsettings.json");

            var folderPath = Path.Join(directoryPath, folderName);
            Directory.CreateDirectory(folderPath);

            var fileName = configuration["SortingResultFileName"];
            if (fileName == null)
                throw new NullReferenceException("SortingResultFileName variable not specified in appsettings.json");

            _filePath = Path.Join(folderPath + "\\" + fileName);
        }

        public void Write(string fileContent)
        {
            var fullFilePath = _filePath + " " + Guid.NewGuid() + ".txt";
            File.WriteAllText(fullFilePath, fileContent);
        }
    }
}
