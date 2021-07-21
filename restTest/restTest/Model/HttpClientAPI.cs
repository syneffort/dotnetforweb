//https://github.com/drowsy-n/unity-RESTful-API-example/blob/master/REST_ful_API.cs

using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace restTest.Model
{
    public class HttpClientAPI
    {
        public HttpClientAPI()
        {
        }

        public static async void Get(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic");

            var response = await client.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            string jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);
        }
    }
}
