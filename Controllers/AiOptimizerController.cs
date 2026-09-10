using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.AiOptimizer.Controllers;

/// <summary>
/// Serves LLM discovery endpoints (llms.txt and llms-full.txt)
/// </summary>
public class AiOptimizerController : BasePluginController
{
    private readonly IStoreContext _storeContext;
    private readonly AiOptimizerSettings _settings;

    public AiOptimizerController(
        IStoreContext storeContext,
        AiOptimizerSettings settings)
    {
        _storeContext = storeContext;
        _settings = settings;
    }

    [HttpGet]
    public async Task<IActionResult> LlmsTxt()
    {
        if (!_settings.EnableLlmsTxt)
            return NotFound();

        if (!string.IsNullOrWhiteSpace(_settings.CustomLlmsTxtContent))
            return Content(_settings.CustomLlmsTxtContent, "text/plain; charset=utf-8");

        var store = await _storeContext.GetCurrentStoreAsync();
        var storeUrl = store?.Url?.TrimEnd('/') ?? "https://aundo-shop.de";
        var storeName = store?.Name ?? "A&O - Internationales Frischezentrum";

        return Content(AiOptimizerDefaults.GetDefaultLlmsTxt(storeName, storeUrl), "text/plain; charset=utf-8");
    }

    [HttpGet]
    public async Task<IActionResult> LlmsFullTxt()
    {
        if (!_settings.EnableLlmsTxt)
            return NotFound();

        if (!string.IsNullOrWhiteSpace(_settings.CustomLlmsFullTxtContent))
            return Content(_settings.CustomLlmsFullTxtContent, "text/plain; charset=utf-8");

        return await LlmsTxt();
    }
}
