using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace NetHttp
{
    public enum HttpMethodType
    {
        POST,
        GET,
        DELETE,
        PUT
    }

    public enum MediaType
    {
        JSON,
        XML
    }

    public class HttpRequest
    {

        private string mediaType;

        public HttpRequest(MediaType mediaType = MediaType.JSON)
        {
            switch (mediaType)
            {
                case MediaType.JSON:
                    this.mediaType = "application/json";
                    break;
                case MediaType.XML:
                    this.mediaType = "application/xml";
                    break;
            }
        }

        /// <summary>
        /// Http get request
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Promise</returns>
        public Promise Get(string url)
        {
            Promise p = new Promise(mediaType,url, HttpMethodType.GET);
            return p;
        }

        /// <summary>
        /// Http post request
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Promise Post(string url,string data)
        {
            Promise p = new Promise(mediaType, url,data, HttpMethodType.POST);
            return p;
        }

        public Promise Delete(string url)
        {
            Promise p = new Promise(mediaType, url, HttpMethodType.DELETE);
            return p;
        }

        public Promise Put(string url, string data)
        {
            Promise p = new Promise(mediaType, url, data, HttpMethodType.PUT);
            return p;
        }

    }
}
