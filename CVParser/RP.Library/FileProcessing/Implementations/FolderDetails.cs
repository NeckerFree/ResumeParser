using RP.Library.FileProcessing.Interfaces;

namespace RP.Library.FileProcessing.Implementations
{
    internal class FolderDetails : IFolderDetails
    {
        private string _folder;

        public FolderDetails(string folder)
        {
            this._folder=folder;
        }

        public bool ValidFolder()
        {
           return Directory.Exists(_folder);
        }
    }
}
