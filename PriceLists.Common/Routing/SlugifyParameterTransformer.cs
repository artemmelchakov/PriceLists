using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace PriceLists.Common.Routing;

/// <summary> Преобразователь маршрутов в стиль с прописными буквами с дефисом между словами. </summary>
/// <example> MyController/MyAction преобразует в my-controller/my-action </example>
public partial class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    [GeneratedRegex("([a-z])([A-Z])")]
    private static partial Regex Regex();

    public string? TransformOutbound(object? value) => value == null ? null : Regex().Replace(value.ToString()!, "$1-$2").ToLower();
}
