//using System.Text;
//using System.Net;
//using RP.Library.FileProcessing.Implementations;

//class Program
//{
//    //Set APIURL as rest api url for resume parsing provided by RChilli.
//    static String APIURL = "https://{{baseurl}}.rchilli.com/RChilliParser/Rchilli/parseResumeBinary";
//    //Set USERKEY as provided by RChilli.
//    static String USERKEY = "Your API UserKey";
//    static String VERSION = "8.0.0";
//    static void Main(string[] args)
//    {
//        //Set resume file path
//        String filePath = @"C:\resumefolder\resume.doc";
//        FileInfo file = new FileInfo(filePath);
//        byte[] DataFile = converttoBase64(file);
//        String subUserId = "Your Company Name";
//        String request = "{\"filedata\":\"" + Convert.ToBase64String(DataFile)
//                            + "\",\"filename\":\"" + file.Name
//                            + "\",\"userkey\":\"" + USERKEY
//                            + "\",\"version\":\"" + VERSION
//                            + "\",\"subuserid\":\"" + subUserId
//                            + "\"}";
//        byte[] byteArray = Encoding.UTF8.GetBytes(request);
//        HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(APIURL);
//        httpRequest.Credentials = CredentialCache.DefaultCredentials;
//        httpRequest.Method = "POST";
//        httpRequest.ContentType = "application/json";
//        httpRequest.ContentLength = byteArray.Length;
//        httpRequest.Timeout = 300000;
//        Stream dataStream = httpRequest.GetRequestStream();
//        dataStream.Write(byteArray, 0, byteArray.Length);
//        dataStream.Close();

//        HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
//        StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.UTF8);
//        String response = streamReader.ReadToEnd();
//        Console.WriteLine(response);
//        Console.ReadKey();

//    }
//    public static byte[] converttoBase64(FileInfo fno)
//    {
//        try
//        {
//            Int64 numofbyte = fno.Length;
//            FileStream fs = new FileStream(fno.FullName, FileMode.Open);
//            BinaryReader br = new BinaryReader(fs);
//            byte[] DataFile = br.ReadBytes(Convert.ToInt32(numofbyte));
//            fs.Close();
//            fs.Dispose();
//            return DataFile;
//        }
//        catch (Exception ex)
//        {
//        }
//        byte[] error1 = new byte[1];
//        error1[0] = (byte)' ';
//        return error1;
//    }
//}
