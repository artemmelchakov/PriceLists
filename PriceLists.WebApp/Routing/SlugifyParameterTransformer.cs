using System.Text.RegularExpressions;

namespace PriceLists.WebApp.Routing;

/// <summary> Преобразователь маршрутов в стиль с прописными буквами с дефисом между словами. </summary>
/// <example> MyController/MyAction преобразует в my-controller/my-action </example>
public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value) => 
        value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
}
