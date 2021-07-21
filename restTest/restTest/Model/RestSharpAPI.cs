using System;
using RestSharp;

namespace restTest.Model
{
    public class RestSharpAPI
    {
        public RestSharpAPI()
        {
        }

        public static string GET(string url)
        {
            RestClient client = new RestClient(url);
            client.Timeout = -1;
            RestRequest request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            Console.WriteLine($"statuscode: {response.StatusCode}"); ;
            return response.Content;
        }
    }
}
