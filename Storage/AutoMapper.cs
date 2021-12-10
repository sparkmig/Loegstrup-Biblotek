using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public static class AutoMapper
    {
        public static TModel Map<TModel>(this object from) where TModel : class, new()
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = typeof(TModel).GetProperties();

            TModel model = new TModel();

            foreach (var property in fromProperties)
            {
                PropertyInfo toProperty = null;

                toProperty = toProperties.FirstOrDefault(o => o.Name == property.Name && o.PropertyType == property.PropertyType);

                if (toProperty != null)
                {
                    toProperty.SetValue(model, property.GetValue(from));
                }
            }
            return model;
        }
    }
}
