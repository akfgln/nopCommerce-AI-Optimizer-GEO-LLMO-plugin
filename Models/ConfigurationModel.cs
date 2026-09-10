using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.AiOptimizer.Models;

/// <summary>
/// Configuration model for plugin admin page
/// </summary>
public record ConfigurationModel : BaseNopModel
{
    public bool EnableLlmsTxt { get; set; }
    public bool EnableStoreSchema { get; set; }
    public bool EnableHalalDietSchema { get; set; }
    public bool EnableFaqSchema { get; set; }
    public string CustomLlmsTxtContent { get; set; } = string.Empty;
    public string CustomLlmsFullTxtContent { get; set; } = string.Empty;
    public string StoreUrl { get; set; } = string.Empty;
}
