namespace Nop.Plugin.Misc.AiOptimizer.Models;

/// <summary>
/// Model for rendering Schema.org JSON-LD tags in head
/// </summary>
public record AiOptimizerModel
{
    public string LangCode { get; init; } = "de";
    public bool IsHome { get; init; }
    public bool IsProduct { get; init; }
    public bool EnableStoreSchema { get; init; }
    public bool EnableHalalDietSchema { get; init; }
    public bool EnableFaqSchema { get; init; }
    public string StoreName { get; init; } = "A&O - Internationales Frischezentrum";
    public string StoreUrl { get; init; } = "https://aundo-shop.de";
}
