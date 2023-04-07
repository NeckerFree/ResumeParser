
namespace RP.Testing
{
    public class FileDetailsTests
    {
        [Fact]
        public void ValidateFileInfo()
        {
            FileDetails fileDetails = new FileDetails("C:\\Elio\\Personal\\Colpatria", "202304_0708_16215_576982525.pdf");
            FileInfo fileInfo = fileDetails.GetFileInfo();
            Assert.Equal(".pdf", fileInfo.Extension);

        }

        [Fact]
        public void ValidateToBase64Conversion()
        {
            FileDetails fileDetails = new FileDetails("C:\\Elio\\Personal\\Colpatria", "202304_0708_16215_576982525.pdf");
            FileInfo fileInfo = fileDetails.GetFileInfo();
            FileConverter fileConverter = new FileConverter(fileDetails);
            byte[] binaryFile = fileConverter.ConvertToBase64();
            Assert.Equal(fileInfo.Length, binaryFile.Length);

        }
        [Fact]
        public void ValidateFromBase64Conversion()
        {
            string folder = "C:\\Elio\\Personal\\Colpatria";
            string fileName = "test.pdf";
            FileDetails fileDetails = new FileDetails(folder, "202304_0708_16215_576982525.pdf");
            FileInfo fileInfo = fileDetails.GetFileInfo();
            FileConverter fileConverter = new FileConverter(fileDetails);
            byte[] binaryFile = fileConverter.ConvertToBase64();
            string fullPath = Path.Combine(folder, fileName);
            fileConverter.ConvertFromBase64(binaryFile, fullPath);
            Assert.True(File.Exists(fullPath));
        }
    }
}