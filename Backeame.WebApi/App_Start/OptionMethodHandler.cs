using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace Backeame.WebApi.App_Start
{
    public class OptionMethodHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //if the command is: 'OPTIONS'
            if (request.Method == HttpMethod.Options)
            {
                var response = request.CreateResponse(HttpStatusCode.OK);
                //allow cross origin
                //response.Headers.Add("Access-Control-Allow-Origin", "*");
                ////allow all http methods
                //response.Headers.Add("Access-Control-Allow-Methods", "*");
                ////below the two headers that I want to allow
                //response.Headers.Add("Access-Control-Allow-Headers", "token");
                ////age of the access control
                //response.Headers.Add("Access-Control-Max-Age", "360000");

                return await Task.Factory.StartNew(() => response, cancellationToken);
            }
            //otherwise let the request pass through
            return await base.SendAsync(request, cancellationToken);
        }
    }
}

