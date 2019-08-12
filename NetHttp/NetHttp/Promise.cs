using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace NetHttp
{

    public class Promise
    {
        private string url;
        private string data;
        private HttpMethodType method;
        private string mediaType;

        public Promise(string mediaType,string url,HttpMethodType method)
        {
            this.url = url;
            this.method = method;
            this.mediaType = mediaType;
        }

        public Promise(string mediaType,string url, string data, HttpMethodType method)
        {
            this.url = url;
            this.data = data;
            this.method = method;
            this.mediaType = mediaType;
        }

        public async void Then(Action<string> func)
        {
            HttpClient client = new HttpClient();

            using (HttpResponseMessage res = await GetHttpMethod(url,method))
            {
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    func(data);
                }
            }
        }

        async Task<HttpResponseMessage> GetHttpMethod(string url, HttpMethodType method)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(mediaType));

            switch (method)
            {
                case HttpMethodType.POST:
                    return await client.PostAsync(url,new StringContent(data));
                case HttpMethodType.GET:
                    return await client.GetAsync(url);
                case HttpMethodType.DELETE:
                    return await client.DeleteAsync(url);
                case HttpMethodType.PUT:
                    return await client.PutAsync(url, new StringContent(data));
                default:
                    throw new System.Exception("This http method does't exist or is currently not supported.");
            }
            
        }

    }
}
