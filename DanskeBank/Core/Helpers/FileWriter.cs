using Core.Interfaces;
using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Core.Helpers
{
    public class FileWriter : IFileWriter
    {
        private string _folderPath;
        private string _filePath;

        public FileWriter(IConfiguration configuration, IHostingEnvironment env)
        {
            var directoryPath = env.ContentRootPath;
            var folderName = configuration["SortingResultFolderName"];
            if (folderName == null)
                throw new NullReferenceException("SortingResultFolderName variable not specified in appsettings.json");

            _folderPath = Path.Join(directoryPath, folderName);
            Directory.CreateDirectory(_folderPath);

            var fileName = configuration["SortingResultFileName"];
            if (fileName == null)
                throw new NullReferenceException("SortingResultFileName variable not specified in appsettings.json");

            _filePath = Path.Join(_folderPath + "\\" + fileName);
        }

        public void Write(string fileContent)
        {
            var fullFilePath = _filePath + " " + Guid.NewGuid() + ".txt";
            File.WriteAllText(fullFilePath, fileContent);
        }

        public int[] GetLatestFileWritten()
        {
            var directory = new DirectoryInfo(_folderPath);
            var file = directory.GetFiles().OrderByDescending(f => f.LastWriteTime).First();
            var latestSortedNumbers = ParseFileToIntArray(file);

            return latestSortedNumbers;
        }

        public int[] ParseFileToIntArray(FileInfo file)
        {
            var fileContent = File.ReadAllText(file.FullName);
            int[] latestSortedNumbers = fileContent.Split(" ").Select(s => Int32.Parse(s)).ToArray();
            return latestSortedNumbers;
        }
    }
}
