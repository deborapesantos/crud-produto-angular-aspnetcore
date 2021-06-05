using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution_CrudProduto.Domain
{
    public class Utils
    {
        /// <summary>
        /// Realiza cópia de valores de source para destination
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void CopyPropertyValues(object source, object destination)
        {
            if (source != null)
            {
                var destProperties = destination.GetType().GetProperties();

                foreach (var sourceProperty in source.GetType().GetProperties())
                {
                    foreach (var destProperty in destProperties)
                    {
                        if (destProperty.Name == sourceProperty.Name && 
                            destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                        {
                            destProperty.SetValue(destination, sourceProperty.GetValue(source, new object[] { }), new object[] { });
                            break;
                        }
                    }
                }
            }
        }

       
    }
}
