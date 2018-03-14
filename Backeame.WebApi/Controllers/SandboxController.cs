using Backeame.Business;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Backeame.WebApi.Controllers
{
    [RoutePrefix("api/sandbox")]
    [AllowAnonymous]
    public class SandboxController : ApiController
    {
        private readonly ITestLogic _testLogic;

        public SandboxController()
        {

        }
        public SandboxController(ITestLogic testLogic)
        {
            this._testLogic = testLogic;
        }
        //[HttpGet]
        //public IEnumerable<Backer> Index()
        //{
        //    IEnumerable<Backer> backerList = _backerLogic.GetAllBackers();
        //    return backerList;
        //}

        [HttpGet]
        [Route("api/sandbox/getall")]
        public IEnumerable<String> TestList()
        {
            return new string[] { "corcho", "se", "la", "come" };
        }

        [HttpGet]
        [Route("api/sandbox/seed")]
        public HttpResponseMessage Seed()
        {
            _testLogic.Seed();
            return JsonResponse.Response("OK", Request);
        }

        [HttpPost]
        [Route("api/sandbox/post")]
        public HttpResponseMessage Add()
        {
            return JsonResponse.Response("",Request);
        }
    }
}
