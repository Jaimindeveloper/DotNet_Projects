using System.Text.RegularExpressions;

namespace CustomConstraints.CustomConstraints
{
    public class CustomConstraintsClass : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if(!values.ContainsKey(routeKey))
            {
                return false;
            }

            Regex regex = new Regex(@"^[0-5]+$");
            string? value = values[routeKey]?.ToString();
            if (value != null)
            {
                return regex.IsMatch(value);
            }

            return false;
        }
    }
}
