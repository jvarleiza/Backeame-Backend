using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Backeame.Business;
using Backeame.Data.Entities;
using Backeame.Magic.DTOs;

namespace Backeame.WebApi.Controllers
{
    public class CollectionController : ApiController
    {

        private readonly ICollectionLogic collectionLogic;

        /// <summary>
        /// Contructor
        /// </summary>
        public CollectionController(ICollectionLogic collectionLogic)            
        {
            this.collectionLogic = collectionLogic;
        }
        /// <summary>
        /// Gets the collections of projects that are Trending
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Collection/trending")]
        public HttpResponseMessage Trending()
        {
            return JsonResponse.Response(this.collectionLogic.Trending(), Request);
        }
        /// <summary>
        /// Gets the collections of projects that are Just Launched
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Collection/JustLaunched")]
        public HttpResponseMessage JustLaunched()
        {
            return JsonResponse.Response(this.collectionLogic.JustLaunched(), Request);
        }
        /// <summary>
        /// Gets the collections of projects that are nearly funded
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Collection/NearlyFunded")]
        public HttpResponseMessage NearlyFunded()
        {
            return JsonResponse.Response(this.collectionLogic.NearlyFunded(), Request);
        }
        /// <summary>
        /// Gets the collections of projects that are recommended to us
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Collection/Recommended")]
        public HttpResponseMessage Recommended()
        {
            return JsonResponse.Response(this.collectionLogic.Recommended(), Request);
        }
        /// <summary>
        /// Gets all project for the specified categoriy ID
        /// </summary>
        /// <param name="categoryId">
        /// Arte = 1
        /// Diseño = 2
        /// Moda = 3
        /// FilmVideo = 4
        /// Comida = 5
        /// Juegos = 6
        /// EditorialJournalism = 7
        /// Eventos = 8
        /// InnovacionTecnologia = 9
        /// SoloNiños = 10
        /// PerformanceArts = 11
        /// Travel = 12
        /// UrbanPlanning = 13
        /// VisualArts = 14
        /// Memorials = 15
        /// Animales = 16
        /// Celebraciones = 17
        /// Cultura = 18
        /// Educación = 19
        /// Emergencia = 20
        /// MedioAmbiente = 21
        /// FaithSpirituality = 22
        /// DerechosHumanos = 23
        /// Medical = 24
        /// BeneficioPublico = 25
        /// Deportes = 26
        /// Voluntario = 27
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Collection/Category/{categoryId:int}")]
        public HttpResponseMessage Category(int categoryId)
        {
            return JsonResponse.Response(this.collectionLogic.PerCategory(categoryId), Request);
        }
        /// <summary>
        /// Gets all project for the specified type
        /// </summary>
        /// <param name="type">comercial or ong</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Collection/ProjectType/{type}")]
        public HttpResponseMessage ProjectType(string type)
        {
            return JsonResponse.Response(this.collectionLogic.PerProjectType(Enumerations.GetEnumValueByDescription<ProjectType>(type)), Request);
        }
    }
}
