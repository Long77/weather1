using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace Weather1
{
    class API
    {
        private string url;

        public API(string url)
        {
            this.url = url;
        }

        public virtual async Task<string> GetJSON()
        {
            var http = new HttpClient();
            string reply = await http.GetStringAsync(this.url);
            return reply;
        }

        public async Task<T> GetData<T>()
        {
            string json = await GetJSON();
            T instance = JsonConvert.DeserializeObject<T>(json);
            return instance;
        }
    }


    // interface IJSONConvertable<T> {
    //     public T ToObject<T>(string json);
    // }

    // class GoogleAPI : API, IJSONConvertable {
    //     // public override async Task<string> GetJSON(){
    //     //     //.. do something differently
    //     // }

    //     public T ToObject<T>(string json) {

    //     }
    // }

    // class DarkSkyAPI : API, IJSONConvertable {
    //     public T ToObject<T>(string json) {
    //         /// ..
    //     }
    // }

}