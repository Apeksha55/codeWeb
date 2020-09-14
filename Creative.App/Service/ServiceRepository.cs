using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Creative.Web.Service
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }
        public ServiceRepository()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceUrl"].ToString()),
                Timeout = TimeSpan.FromMinutes(30)
            };
           
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, HttpContent model)
        {
            return Client.PutAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, HttpContent model)
        {
            return Client.PostAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}