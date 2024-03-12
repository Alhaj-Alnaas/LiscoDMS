using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CerpApi.ApiServiecs
{
    public class Api
    {
        

        public void GetApi(string ApiUrl)
        {
           // //getToken
           // var request = new Request();
           // var user = new User { username = "Bob", password = "password" };
           // // var user = "your json string here";
           // var response = (Httpresponse)request.Execute<Httpresponse>("http://localhost:1234/", user, "POST");

           // client.DefaultRequestHeaders.Authorization =
           //new AuthenticationHeaderValue("Authorization", "Token " + "token");

            // get token
            //string Userjson = "{\"user\":\"test\"," +
                             //"\"password\":\"bla\"}";
            var response = (HttpWebRequest)WebRequest.Create("https://tools.icona.ly/api/outbox/send/");
            

           
            // send message
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://tools.icona.ly/api/outbox/send/");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authentication", "Token efdb462371b640b148636c41f1e8e1a8f004435c");

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"user\":\"test\"," +
                              "\"password\":\"bla\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }


            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = new JavaScriptSerializer().Serialize(new
            //        [


            //            {"to": "218919749688","message": "اختبار اللغة العربية"},
            //            { "to": "218925008886","message": "اختبار اللغة العربية"}
            //          ]);

            //streamWriter.Write(json);
        }

        //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //{
        //    var result = streamReader.ReadToEnd();
        //}


        //getToken
        //var token = getToken;

        // }


        //public static string PostApi(string ApiUrl, string postData = "")
        //{

        //    var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
        //    var data = Encoding.ASCII.GetBytes(postData);
        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    request.ContentLength = data.Length;
        //    using (var stream = request.GetRequestStream())
        //    {
        //        stream.Write(data, 0, data.Length);
        //    }
        //    var response = (HttpWebResponse)request.GetResponse();
        //    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    return responseString;
        //}

        private static string doRequestWithBytesPostData(string requestUri, string method, byte[] postData,
                                        CookieContainer cookieContainer,
                                        string userAgent, string acceptHeaderString,
                                        string referer,
                                        string contentType, out string responseUri)
        {
            var result = "";
            if (!string.IsNullOrEmpty(requestUri))
            {
                var request = WebRequest.Create(requestUri) as HttpWebRequest;
                if (request != null)
                {
                    request.KeepAlive = true;
                    var cachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
                    request.CachePolicy = cachePolicy;
                    request.Expect = null;
                    if (!string.IsNullOrEmpty(method))
                        request.Method = method;
                    if (!string.IsNullOrEmpty(acceptHeaderString))
                        request.Accept = acceptHeaderString;
                    if (!string.IsNullOrEmpty(referer))
                        request.Referer = referer;
                    if (!string.IsNullOrEmpty(contentType))
                        request.ContentType = contentType;
                    if (!string.IsNullOrEmpty(userAgent))
                        request.UserAgent = userAgent;
                    if (cookieContainer != null)
                        request.CookieContainer = cookieContainer;

                    //request.Timeout = Constants.RequestTimeOut;

                    if (request.Method == "POST")
                    {
                        if (postData != null)
                        {
                            request.ContentLength = postData.Length;
                            using (var dataStream = request.GetRequestStream())
                            {
                                dataStream.Write(postData, 0, postData.Length);
                            }
                        }
                    }

                    using (var httpWebResponse = request.GetResponse() as HttpWebResponse)
                    {
                        if (httpWebResponse != null)
                        {
                            responseUri = httpWebResponse.ResponseUri.AbsoluteUri;
                            cookieContainer.Add(httpWebResponse.Cookies);
                            using (var streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                            {
                                result = streamReader.ReadToEnd();
                            }
                            return result;
                        }
                    }
                }
            }
            responseUri = null;
            return null;
        }

       
       

    }
}
