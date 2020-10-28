using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace ATN.Utils.Web
{
    public static class IO
    {
        public static string Get(string uri, Func<HttpWebRequest, HttpWebRequest> WebrequestAlteration)
        {
            Debug.WriteLine(uri);

            HttpWebRequest request = GetHttpWebRequest(uri, "","GET",0);

            request = WebrequestAlteration(request);

            

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static  async Task<string> GetAsync(string uri, Func<HttpWebRequest, HttpWebRequest> WebrequestAlteration)
        {
            HttpWebRequest request = GetHttpWebRequest(uri, "", "GET", 0);

            request = WebrequestAlteration(request);

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static string Post(string uri, string data, string contentType, Func<HttpWebRequest, HttpWebRequest> WebrequestAlteration)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = GetHttpWebRequest(uri, contentType, "POST", dataBytes.Length);

            request = WebrequestAlteration(request);

            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static  async Task<string> PostAsync(string uri, string data, string contentType, Func<HttpWebRequest, HttpWebRequest> WebrequestAlteration)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            HttpWebRequest request = GetHttpWebRequest(uri, contentType,"POST", dataBytes.Length);

            request = WebrequestAlteration(request);

            using (Stream requestBody = request.GetRequestStream())
            {
                await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private static HttpWebRequest GetHttpWebRequest(string uri, string contentType, string method, int dataBytesLength)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytesLength;
            request.ContentType = contentType;
            request.Method = method;
            return request;
        }

        public static string CreateParamString(Dictionary<string, string> requestParams)
        {
            string requestBody = "";
            foreach (var pair in requestParams)
            {
                requestBody += WebUtility.UrlEncode(pair.Key) + "=" + WebUtility.UrlEncode(pair.Value) + "&";
            }
            requestBody = requestBody.Trim('&');
            return requestBody;
        }
    }
}
