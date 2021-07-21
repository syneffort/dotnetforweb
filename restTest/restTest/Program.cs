using System;
using System.Collections.Generic;
using restTest.Model;
using Newtonsoft.Json;

namespace restTest
{
    class Program
    {
        const string BASE_URL= "https://v2.washswat.com/address/";

        static void Main(string[] args)
        {
            string keyword = "세탁특공대";
            if (args != null && args.Length > 0 && args[0] != null && args[0] != string.Empty)
                keyword = args[0];

            //string response = callWebRequest(keyword);
            //Console.WriteLine(response);
            //Result data = JsonConvert.DeserializeObject<Result>(response);

            string response = callRestSharpRequest(keyword);
            Console.WriteLine(response);
            Result data = JsonConvert.DeserializeObject<Result>(response);
        }

        public static string callWebRequest(string param)
        {
            string url = $"{BASE_URL}search?q={param}";
            return WebReqAPI.Request("GET", url);
        }

        public static void callHttpClientRequest(string param)
        {
            string url = $"{BASE_URL}search?q={param}";
            HttpClientAPI.Get(url);
        }

        public static string callRestSharpRequest(string param)
        {
            string url = $"{BASE_URL}search?q={param}";
            return RestSharpAPI.GET(url);
        }

        class Result
        {
            public string result { get; set; }
            public int code { get; set; }
            public int count { get; set; }
            public List<Info> data { get; set; }

            public class Info
            {
                public string latitude { get; set; }
                public string longitude { get; set; }
                public string address { get; set; }
                public string roadAddress { get; set; }
                public string title { get; set; }
                public string bCode { get; set; }
                public bool isOpen { get; set; }
            }
        }
    }
}