using Backeame.Data;
using Backeame.Magic.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backeame.WebApi.Helpers
{
    /// <summary>
    /// Convert list to JArray
    /// </summary>
    public static class JArrayHelper
    {
        /// <summary>
        /// Maps all objects in the IEnumerable to a JArray
        /// </summary>
        /// <typeparam name="TEntity">Entity must have MapEntity as base class</typeparam>
        /// <param name="source">IEnumerable of entities</param>
        /// <param name="customMap">Entity has custom map</param>
        /// <param name="prms">Properties to map</param>
        /// <returns>JArray of entities mapped to dynamic objects</returns>
        public static JArray MapAll<TEntity>(this IEnumerable<TEntity> source, bool customMap = false, params string[] prms)
            where TEntity : BaseEntity, new()
        {
            JArray result = null;

            if (source.IsNotEmpty())
            {
                result = new JArray();
            }
            foreach (var item in source.ToList())
            //It's too important the .ToList() because it prevents throw exception "Collection was modified; enumeration operation may not execute."
            {
                //MappingIndividualValues
                result.Add(item.Map(customMap: customMap, prms: prms));
            }

            return result;
        }
    }
}