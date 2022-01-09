using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Routing;

namespace TeUserManagement.Helpers
{
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object? value)
        {
            return Regex.Replace(value?.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
