using System;
using System.Net;
using System.IO;

namespace restTest.Model
{
    public class WebReqAPI
    {
        public WebReqAPI()
        {
        }

        public static string Request(string method, string url)
        {
            string jsonString = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = method;
                request.ContentType = "application/json";
                request.Headers["user-agent"] = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";

                using (WebResponse response = request.GetResponse())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    jsonString = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return jsonString;
        }
    }
}
