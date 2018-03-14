using Backeame.Business;
using Backeame.Data;
using Backeame.WebApi.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backeame.WebApi.Controllers
{
    /// <summary>
    /// Base Controller, provides generic RESTfull operations
    /// </summary>
    /// <typeparam name="TEntity">Model entity</typeparam>
    public abstract class BaseController<TEntity> : ApiController
        where TEntity : BaseEntity, new()
    {
        /// <summary>
        /// Base logic, must be implemented on concrete controller
        /// </summary>
        protected IBaseLogic<TEntity> baseLogic = null;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="baseLogic"></param>
        public BaseController(IBaseLogic<TEntity> baseLogic)
        {
            this.baseLogic = baseLogic;
        }

        #region HTTP GETs

        /// <summary>
        /// GET. Gets all records in database
        /// </summary>
        /// <returns>JArray of entities</returns>
        [HttpGet]
        public virtual HttpResponseMessage GetAll()
        {
            HttpResponseMessage result = null;
            try
            {
                result = JsonResponse.Response(Ok(baseLogic.GetAll().MapAll(true)),Request);
            }
            catch (Exception ex)
            {
                result = ProccessException(ex);//InternalServerError(Helpers.ExceptionHelper.ProccessException(ex));
            }
            return result;
        }

        /// <summary>
        /// GET. Obtain data for a paginated
        /// </summary>
        /// <param name="id">Current Page</param>
        /// <param name="id1">Element count</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getpage/{id?}/{id1?}")]
        public virtual HttpResponseMessage GetPage(int id = 0, int id1 = 20)
        {
            HttpResponseMessage result = null;
            try
            {
                result = JsonResponse.Response(Ok(baseLogic.GetSegment(page: id, elementCount: id1).MapAll(true)),Request);
            }
            catch (Exception ex)
            {
                result = ProccessException(ex);
            }
            return result;
        }

        /// <summary>
        /// GET. Get entity by its identifier
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/{id}")]
        public virtual HttpResponseMessage Get(int id)
        {
            HttpResponseMessage result = null;
            try
            {
                TEntity entidad = baseLogic.Get(id);

                if (entidad == null)
                {
                    result = JsonResponse.Response(NotFound(),Request);
                }
                else
                {
                    result = Ok(entidad.Map());
                }
            }
            catch (Exception ex)
            {
                result = ProccessException(ex);
            }

            return result;
        }

        #endregion

        #region HTTP POSTs

        /// <summary>
        /// POST. Create new entity
        /// </summary>
        /// <param name="entityObj">New entity</param>
        /// <returns></returns>
        [HttpPost]
        public virtual HttpResponseMessage Post([FromBody]TEntity entityObj)
        {
            HttpResponseMessage result = null;
            try
            {
                //Prevents addition of unwanted data nested objects are removed.
                //It's a security task too, it prevents addition of related objects through a parent obj
                entityObj = entityObj.Map().ToObject<TEntity>();

                if (!ModelState.IsValid)
                {
                    result = JsonResponse.Response(BadRequest(ModelState),Request);
                }
                else
                {
                    if (baseLogic.Create(entityObj))
                        result = Ok(entityObj.Map(true));
                    else
                        result = JsonResponse.Response(InternalServerError(), Request);
                }
            }
            catch (Exception ex)
            {
                result = ProccessException(ex);
            }

            return result;
        }

        /// <summary>
        /// POST. Filters records by properties in JObject
        /// </summary>
        /// <param name="item">Jobject with the params to filter</param>
        /// <returns>Jarray of entities that matched the search</returns>
        [HttpPost]
        [Route("filterby")]
        public virtual HttpResponseMessage FilterBy([FromBody]JObject item)
        {
            HttpResponseMessage result = null;
            try
            {
                TEntity entity = new TEntity();
                result = JsonResponse.Response(Ok(baseLogic.GetAll().Where(x => x.PropertiesMatch(item)).MapAll(true)), Request); ;
            }
            catch (Exception ex)
            {
                result = ProccessException(ex);
            }
            return result;
        }

        #endregion

        #region HTTP PUTs

        /// <summary>
        /// PUT. Edits a entitiy
        /// </summary>
        /// <param name="id">Entity identifier</param>
        /// <param name="entityObj">Updated entity</param>
        /// <returns></returns>
        [HttpPut]
        [Route("put")]
        public virtual HttpResponseMessage Put(long id, [FromBody]TEntity entityObj)
        {
            HttpResponseMessage result = null;
            try
            {
                if (!ModelState.IsValid)
                {
                    result = JsonResponse.Response(BadRequest(ModelState),Request);
                }
                else
                {
                    if (baseLogic.Update(entityObj))
                        result = Ok(entityObj.Map(true));
                    else
                        result = JsonResponse.Response(InternalServerError(), Request);
                }
            }
            catch (Exception ex)
            {
                result = ProccessException(ex);
            }

            return result;
        }

        #endregion

        #region HTTP DELETEs

        /// <summary>
        /// DELETE. Delete a entity
        /// </summary>
        /// <param name="id">Entitiy identifier</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public virtual HttpResponseMessage Delete(long id)
        {
            HttpResponseMessage result = null;
            try
            {
                if (baseLogic.Delete(id))
                    return JsonResponse.Response(Ok(), Request);
                else
                    result = JsonResponse.Response(InternalServerError(), Request);
            }
            catch (Exception ex)
            {
                result = ProccessException(ex);
            }

            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Disposes service before dispose controleer
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            baseLogic.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Handles api exceptions
        /// </summary>
        /// <param name="exGot">Exception</param>
        /// <returns></returns>
        [NonAction]
        protected virtual HttpResponseMessage ProccessException(Exception exGot)
        {
            HttpResponseMessage result = null;
            try
            {
                //Ex of how to use -> if (exGot is DbEntityValidationException) then process exception
                result = JsonResponse.Response(InternalServerError(exGot),Request);
            }
            catch (Exception ex)
            {
                result = JsonResponse.Response(InternalServerError(ex),Request);
            }

            return result;
        }
        #endregion        
    }
}