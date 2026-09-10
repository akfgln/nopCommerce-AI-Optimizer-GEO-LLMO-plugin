using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.AiOptimizer.Models;
using Nop.Web.Framework.Components;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Misc.AiOptimizer.Components;

/// <summary>
/// View component for injecting localized Schema.org JSON-LD tags into head_html_tag
/// </summary>
public class AiOptimizerHeadViewComponent : NopViewComponent
{
    private readonly IWorkContext _workContext;
    private readonly IStoreContext _storeContext;
    private readonly AiOptimizerSettings _settings;

    public AiOptimizerHeadViewComponent(
        IWorkContext workContext,
        IStoreContext storeContext,
        AiOptimizerSettings settings)
    {
        _workContext = workContext;
        _storeContext = storeContext;
        _settings = settings;
    }

    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        if (!string.Equals(widgetZone, PublicWidgetZones.HeadHtmlTag, StringComparison.OrdinalIgnoreCase))
            return Content(string.Empty);

        var controller = RouteData.Values["controller"]?.ToString();
        var action = RouteData.Values["action"]?.ToString();

        var isHome = (string.Equals(controller, "Home", StringComparison.OrdinalIgnoreCase) &&
                      string.Equals(action, "Index", StringComparison.OrdinalIgnoreCase)) ||
                     string.IsNullOrEmpty(controller);

        var isProduct = string.Equals(controller, "Product", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(action, "ProductDetails", StringComparison.OrdinalIgnoreCase);

        // If not home and not product, nothing to inject
        if (!isHome && !isProduct)
            return Content(string.Empty);

        var language = await _workContext.GetWorkingLanguageAsync();
        var langCode = language?.UniqueSeoCode?.ToLowerInvariant() ?? "de";
        var store = await _storeContext.GetCurrentStoreAsync();

        var model = new AiOptimizerModel
        {
            LangCode = langCode,
            IsHome = isHome,
            IsProduct = isProduct,
            EnableStoreSchema = _settings.EnableStoreSchema,
            EnableHalalDietSchema = _settings.EnableHalalDietSchema,
            EnableFaqSchema = _settings.EnableFaqSchema,
            StoreName = store?.Name ?? "A&O - Internationales Frischezentrum",
            StoreUrl = (store?.Url?.TrimEnd('/') ?? "https://aundo-shop.de")
        };

        return View("~/Plugins/Misc.AiOptimizer/Views/HeadTag.cshtml", model);
    }
}
