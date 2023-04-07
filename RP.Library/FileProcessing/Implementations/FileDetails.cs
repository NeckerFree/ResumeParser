using RP.Library.FileProcessing.Interfaces;

namespace RP.Library.FileProcessing.Implementations
{
    public class FileDetails : IFileDetails
    {
        private string _folder;

        private string _fileName;
        
        public string _path;

        public int bytesLength;

        public FileDetails(string folder, string file)
        {   
             this._folder = folder;
            this._fileName = file;
            this._path = Path.Combine(_folder, _fileName);
        }
        public FileInfo GetFileInfo()
        {
            FolderDetails folderDetails = new FolderDetails(_folder);
            if (folderDetails.ValidFolder())
            {
                if (ValidateFile())
                {
                    FileInfo fileInfo = new FileInfo(_path);
                    bytesLength=(int)fileInfo.Length;
                    return fileInfo;
                }
            }
            throw new FileNotFoundException();
        }

        public bool ValidateFile()
        {
     
         return File.Exists(_path);
        }
    }
}
