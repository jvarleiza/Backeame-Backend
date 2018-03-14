using Backeame.Data.Interfaces;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;

namespace Backeame.Data
{
    public abstract class BaseEntity : ISoftDelete
    {
        /// <summary>
        /// Entity identifier
        /// </summary>
        public virtual long Id { get; set; }

        /// <summary>
        /// Soft delete. Bool to indicate if entity is deleted
        /// </summary>
        public virtual bool IsDeleted { get; set; }

        /// <summary>
        /// Method to map object from .Net to JObject (with only needed data)
        /// </summary>
        /// <param name="customMap">Flag to indicate if it's needed to use custom map (if is present)</param>
        /// <param name="prms">If is set, that parameters will only be mapped</param>
        /// <returns>Object mapped</returns>
        public virtual dynamic Map(bool customMap = false, params string[] prms)
        {
            //This is a generic map method, custom map should override it (calling to it or not)
            dynamic result = null;

            PropertyInfo[] objProperties = this.GetType().GetProperties();

            if (prms.Length > 0)
            {
                objProperties = objProperties.Where(x => prms.Contains(x.Name)).ToArray();
            }

            foreach (PropertyInfo pi in objProperties)
            {
                var propertyType = pi.PropertyType;
                var propertyTypeInfo = pi.PropertyType.GetTypeInfo();
                var propertyTypeFullName = propertyType.FullName;

                if (propertyTypeInfo != null && propertyTypeInfo.IsPrimitive ||
                            propertyTypeFullName.Contains("System.Int") || //when int primitives are nullables it's needed
                            propertyTypeFullName.Contains("System.DateTime") ||
                            propertyTypeFullName.Contains("System.Decimal") ||
                            propertyTypeFullName.Contains("System.Float") ||
                            propertyTypeFullName.Contains("System.Double") ||
                            propertyTypeFullName.Contains("System.String") ||
                            propertyTypeFullName.Contains("System.Boolean") ||
                            propertyTypeFullName.Contains("System.Byte") ||
                            propertyTypeFullName.Contains("System.Guid"))
                {
                    if (pi.CanWrite)
                    {
                        var valueToAdd = pi.GetValue(this);
                        if (valueToAdd != null)
                        {
                            if (result == null)
                            {
                                result = new JObject();
                            }
                            result.Add(pi.Name, new JValue(valueToAdd));
                        }

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Checks if objects has property
        /// </summary>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public virtual bool HasProperty(string propertyName)
        {
            bool foundProperty = false;

            PropertyInfo[] objProperties = this.GetType().GetProperties();

            if (!string.IsNullOrEmpty(propertyName))
            {
                foundProperty = objProperties.Any(x => x.Name.ToLower().Equals(propertyName.ToLower()));
            }

            return foundProperty;
        }

        /// <summary>
        /// Converts dynamic object to the model Entity
        /// </summary>
        /// <param name="json">Dynamic object to convert to model</param>
        /// <returns></returns>
        public static TEntity ToModel<TEntity>(dynamic json) where TEntity : BaseEntity
        {
            JObject obj = json;
            return obj.ToObject<TEntity>();
        }

        /// <summary>
        /// Method to compare if some properties match with certain object
        /// </summary>
        /// <param name="compareObj">Properties values to compare</param>
        /// <returns>Boolean indicating if the provided properties match with the certain object</returns>
        public bool PropertiesMatch(JObject compareObj)
        {
            bool result = false;
            if (compareObj != null)
            {
                //All properties starting with underscore are special parameters
                foreach (JProperty pr in compareObj.Properties().Where(x => x.Name.StartsWith("_")))
                {

                }

                //All properties NOT starting with underscore are filters
                foreach (JProperty pr in compareObj.Properties().Where(x => !x.Name.StartsWith("_")))
                {
                    var thisObjProp = this.GetType().GetProperty(pr.Name);
                    if (thisObjProp != null)
                    {
                        if (thisObjProp.GetValue(this) != null && thisObjProp.GetValue(this).Equals(pr.Value.ToObject(thisObjProp.PropertyType)))
                        {
                            result = true;
                        }
                        else if (thisObjProp.GetValue(this) == null && pr.Value.ToObject(thisObjProp.PropertyType) == null)
                        {
                            result = true;
                        }

                        if (!result)
                        {
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
