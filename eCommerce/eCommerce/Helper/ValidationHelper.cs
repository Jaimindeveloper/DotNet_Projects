using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eCommerce.Helper
{
    public static class ValidationHelper
    {
        public static List<object> GetErrors<T>(ModelStateDictionary modelState)
        {
            var errors = new List<object>();
            foreach (var kvp in modelState.Where(x => x.Value.Errors.Count > 0))
            {
                errors.Add(new
                {
                    Field = kvp.Key,
                    Errors = kvp.Value.Errors.Select(e =>
                        !string.IsNullOrEmpty(e.ErrorMessage)
                            ? e.ErrorMessage
                            : GetDisplayName<T>(kvp.Key))
                });
            }
            return errors;
        }

        public static string GetDisplayName<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return propertyName;

            var type = typeof(T);
            var parts = propertyName.Split('.');
            Type currentType = type;
            PropertyInfo prop = null;
            foreach (var part in parts)
            {
                prop = currentType.GetProperty(part);
                if (prop == null) return propertyName;
                currentType = prop.PropertyType;
            }

            var displayAttr = prop.GetCustomAttribute<DisplayAttribute>();
            if (displayAttr != null && !string.IsNullOrEmpty(displayAttr.Name))
                return displayAttr.Name;

            var displayNameAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
            if (displayNameAttr != null && !string.IsNullOrEmpty(displayNameAttr.DisplayName))
                return displayNameAttr.DisplayName;

            return prop.Name;
        }
    }
}
