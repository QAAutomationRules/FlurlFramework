using Flurl.Http;
using FLURLPOC.Data;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FLURLPOC.Helpers
{
    public class RESTHelpers
    {

        public static async Task<dynamic> GETRequestAsync<T>(string url, string resource, object headers, string userName,
            string password, CookieCollection cookieCollection = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment(resource)
                .GetAsync()
                .ReceiveJson<T>();

            return response;

        }

        public static async Task<dynamic> GETList(string url, string resource, object headers, string userName,
            string password, CookieCollection cookieCollection = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment(resource)
                .GetJsonListAsync();

            return response;

        }

        public static async Task<dynamic> POSTRequestAsync<T>(string url, string resource,
            object headers, string userName, string password, object body,
            CookieCollection cookieCollection = null )
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment(resource)
                .WithCookies(cookieCollection)
                .PostJsonAsync(body)
                .ReceiveJson<T>();

            return response;

        }

        public static async Task<dynamic> PUTRequestAsync<T>(string url, string resource, object headers,
            string userName, string password, object body, CookieCollection cookieCollection = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment(resource)
                .WithCookies(cookieCollection)
                .PutJsonAsync(body)
                .ReceiveJson<T>();

            return response;

        }

        public static async Task<dynamic> PATCHRequestAsync<T>(string url, string resource, string repoName, object headers,
            string userName, string password, object body, CookieCollection cookieCollection = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment(resource)
                .AppendPathSegment("/" + userName)
                .AppendPathSegment("/" + repoName)
                .WithCookies(cookieCollection)
                .PatchJsonAsync(body)
                .ReceiveJson<T>();

            return response;

        }

        public static async Task<dynamic> DELETERequestAsync(string url, string resource, string repoName, object headers,
            string userName, string password, CookieCollection cookieCollection = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment("/" + repoName)
                .AppendPathSegment("/" + userName)
                .AppendPathSegment(resource)
                .WithCookies(cookieCollection)
                .DeleteAsync();

            return response;

        }

        public static async Task<dynamic> HEADRequestAsync<T>(string url, string resource, object headers,
           string userName, string password, CookieCollection cookieCollection = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment(resource)
                .WithCookies(cookieCollection)
                .HeadAsync()
                .ReceiveJson<T>();

            return response;

        }

        public static async Task<dynamic> OPTIONSRequestAsync<T>(string url, string resource, object headers,
            string userName, string password, CookieCollection cookieCollection = null)
        {
            //Allow SSL exception
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var response = await url
                .WithBasicAuth(userName, password)
                .WithHeaders(headers)
                .AppendPathSegment(resource)
                .WithCookies(cookieCollection)
                .OptionsAsync()
                .ReceiveJson<T>();

            return response;

        }

    }
}
