using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.AiOptimizer;

/// <summary>
/// Represents settings for AI Optimizer plugin
/// </summary>
public class AiOptimizerSettings : ISettings
{
    /// <summary>
    /// Gets or sets a value indicating whether llms.txt endpoints are enabled
    /// </summary>
    public bool EnableLlmsTxt { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether GroceryStore / OnlineStore Schema.org JSON-LD is enabled
    /// </summary>
    public bool EnableStoreSchema { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether HalalDiet Schema.org JSON-LD is enabled on product pages
    /// </summary>
    public bool EnableHalalDietSchema { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether FAQPage Schema.org JSON-LD is enabled
    /// </summary>
    public bool EnableFaqSchema { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether robots.txt is automatically configured for AI crawlers
    /// </summary>
    public bool AutoConfigureRobotsTxt { get; set; } = true;

    /// <summary>
    /// Gets or sets custom content for llms.txt
    /// </summary>
    public string CustomLlmsTxtContent { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets custom content for llms-full.txt
    /// </summary>
    public string CustomLlmsFullTxtContent { get; set; } = string.Empty;
}
