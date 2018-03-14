using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Backeame.WebApi
{
    public static class JsonResponse
    {
        public static HttpResponseMessage Response(Object data,HttpRequestMessage Request)
        {
            string stringData = JsonConvert.SerializeObject(data);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            //response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Content = new StringContent(stringData, Encoding.UTF8, "application/json");
            return response;
        }
    }
}