using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConsoleApplication
{ // you will get this done.
    public class Program
    {   
        public static void Main(string[] args)
        {
            prompt().Wait();
        }

        public static async Task prompt(){
            string result = await getUrl("http://google.com");
            Console.WriteLine(result);
        }

        public static async Task<string> getUrl(string url){
            var http = new HttpClient();
            string reply = await http.GetStringAsync(url);
            return reply;
        }
    }
}