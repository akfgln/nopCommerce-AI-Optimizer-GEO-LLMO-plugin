using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Misc.AiOptimizer.Models;
using Nop.Services.Configuration;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.AiOptimizer.Controllers;

[Area(AreaNames.ADMIN)]
[AuthorizeAdmin]
[AutoValidateAntiforgeryToken]
public class AiOptimizerAdminController : BasePluginController
{
    private readonly ISettingService _settingService;
    private readonly INotificationService _notificationService;
    private readonly IStoreContext _storeContext;
    private readonly AiOptimizerSettings _settings;

    public AiOptimizerAdminController(
        ISettingService settingService,
        INotificationService notificationService,
        IStoreContext storeContext,
        AiOptimizerSettings settings)
    {
        _settingService = settingService;
        _notificationService = notificationService;
        _storeContext = storeContext;
        _settings = settings;
    }

    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> Configure()
    {
        var store = await _storeContext.GetCurrentStoreAsync();
        var storeUrl = store?.Url?.TrimEnd('/') ?? "https://aundo-shop.de";
        var storeName = store?.Name ?? "A&O - Internationales Frischezentrum";

        var content = string.IsNullOrWhiteSpace(_settings.CustomLlmsTxtContent)
            ? AiOptimizerDefaults.GetDefaultLlmsTxt(storeName, storeUrl)
            : _settings.CustomLlmsTxtContent;

        var fullContent = string.IsNullOrWhiteSpace(_settings.CustomLlmsFullTxtContent)
            ? content
            : _settings.CustomLlmsFullTxtContent;

        var model = new ConfigurationModel
        {
            EnableLlmsTxt = _settings.EnableLlmsTxt,
            EnableStoreSchema = _settings.EnableStoreSchema,
            EnableHalalDietSchema = _settings.EnableHalalDietSchema,
            EnableFaqSchema = _settings.EnableFaqSchema,
            CustomLlmsTxtContent = content,
            CustomLlmsFullTxtContent = fullContent,
            StoreUrl = storeUrl
        };

        return View("~/Plugins/Misc.AiOptimizer/Views/Configure.cshtml", model);
    }

    [HttpPost]
    [CheckPermission(StandardPermission.Configuration.MANAGE_PLUGINS)]
    public async Task<IActionResult> Configure(ConfigurationModel model)
    {
        _settings.EnableLlmsTxt = model.EnableLlmsTxt;
        _settings.EnableStoreSchema = model.EnableStoreSchema;
        _settings.EnableHalalDietSchema = model.EnableHalalDietSchema;
        _settings.EnableFaqSchema = model.EnableFaqSchema;
        _settings.CustomLlmsTxtContent = model.CustomLlmsTxtContent ?? string.Empty;
        _settings.CustomLlmsFullTxtContent = model.CustomLlmsFullTxtContent ?? string.Empty;

        await _settingService.SaveSettingAsync(_settings);

        _notificationService.SuccessNotification("Settings and llms.txt content have been saved successfully.");

        return await Configure();
    }
}
