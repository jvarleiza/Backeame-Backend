using AutoMapper;
using Backeame.Business;
using Backeame.Data.Entities;
using Backeame.Magic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backeame.WebApi.Controllers
{
    /// <summary>
    /// The project controller will handle.
    /// </summary>
    public class ProjectController : BaseController<Project>
    {
        private readonly IProjectLogic projectLogic;

        /// <summary>
        /// Contructor
        /// </summary>
        public ProjectController(IProjectLogic projectLogic)
            : base(projectLogic)
        {
            this.projectLogic = projectLogic;
        }

        public override HttpResponseMessage Get(int id)
        {
            Project project = this.projectLogic.Get(id);
            ProjectDTO dto = Mapper.Map<ProjectDTO>(project);
            return JsonResponse.Response(dto, Request);
        }

        /// <summary>
        /// Gets a random project
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/project/tinder")]
        public HttpResponseMessage Tinder()
        {
            Project tinderProject = this.projectLogic.Tinder();
            ProjectShallowDTO projectDTO = Mapper.Map<ProjectShallowDTO>(tinderProject);
            return JsonResponse.Response(projectDTO, Request);
        }

        [HttpPost]
        [Route("api/project/add")]
        public HttpResponseMessage Add([FromBody] ProjectDTO project)
        {
            if (!ModelState.IsValid)
            {
                return JsonResponse.Response(BadRequest(ModelState), Request);
            }
            try
            {
                
                return JsonResponse.Response("", Request);
            }
            catch (Exception ue)
            {
                return JsonResponse.Response(BadRequest(ue.Message), Request);
            }
        }
    }
}
