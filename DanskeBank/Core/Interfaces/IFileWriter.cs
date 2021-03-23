using System.IO;

namespace Core.Interfaces
{
    public interface IFileWriter
    {
        public void Write(string fileContent);
        public int[] GetLatestFileWritten();
        public int[] ParseFileToIntArray(FileInfo file);
    }
}
