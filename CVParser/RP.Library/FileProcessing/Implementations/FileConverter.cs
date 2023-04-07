using RP.Library.FileProcessing.Interfaces;

namespace RP.Library.FileProcessing.Implementations
{
    public class FileConverter : IFileConverter
    {
        private FileDetails _fileDetails;

        public FileConverter(FileDetails fileDetails)
        {
            this._fileDetails = fileDetails;
        }

        public void ConvertFromBase64(byte[] binaryFile, string fullPath)
        {
            File.WriteAllBytes(fullPath, binaryFile);
        }

        public byte[] ConvertToBase64()
        {
            using (var fs = new FileStream(_fileDetails._path, FileMode.Open))
            {
                return new BinaryReader(fs).ReadBytes(_fileDetails.bytesLength);
            }
        }


    }
}
