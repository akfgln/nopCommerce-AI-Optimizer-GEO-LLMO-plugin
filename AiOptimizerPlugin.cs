using System.Text;
using Nop.Core;
using Nop.Core.Domain.Security;
using Nop.Core.Infrastructure;
using Nop.Plugin.Misc.AiOptimizer.Components;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Misc.AiOptimizer;

/// <summary>
/// AI Optimizer plugin for GEO (Generative Engine Optimization) & LLMO
/// </summary>
public class AiOptimizerPlugin : BasePlugin, IWidgetPlugin
{
    private readonly ISettingService _settingService;
    private readonly INopFileProvider _fileProvider;
    private readonly IWebHelper _webHelper;

    public AiOptimizerPlugin(
        ISettingService settingService,
        INopFileProvider fileProvider,
        IWebHelper webHelper)
    {
        _settingService = settingService;
        _fileProvider = fileProvider;
        _webHelper = webHelper;
    }

    /// <summary>
    /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
    /// </summary>
    public bool HideInWidgetList => false;

    /// <summary>
    /// Gets a configuration page URL
    /// </summary>
    public override string GetConfigurationPageUrl()
    {
        return $"{_webHelper.GetStoreLocation()}Admin/AiOptimizerAdmin/Configure";
    }

    /// <summary>
    /// Gets widget zones where this widget should be rendered
    /// </summary>
    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>(new List<string>
        {
            PublicWidgetZones.HeadHtmlTag
        });
    }

    /// <summary>
    /// Gets a type of a view component for displaying widget
    /// </summary>
    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(AiOptimizerHeadViewComponent);
    }

    /// <summary>
    /// Install the plugin
    /// </summary>
    public override async Task InstallAsync()
    {
        // 1. Save default settings
        await _settingService.SaveSettingAsync(new AiOptimizerSettings());

        // 2. Configure robots.txt additions in settings
        var robotsSettings = await _settingService.LoadSettingAsync<RobotsTxtSettings>();
        if (!robotsSettings.AdditionsRules.Any(r => r.Contains("GPTBot") || r.Contains(AiOptimizerDefaults.RobotsAdditionMarker)))
        {
            robotsSettings.AdditionsRules.AddRange(AiOptimizerDefaults.DefaultAiRobotsRules);
            await _settingService.SaveSettingAsync(robotsSettings, s => s.AdditionsRules);
        }

        // 3. Also write robots.additions.txt in wwwroot to ensure file-based fallback
        try
        {
            var additionsFilePath = _fileProvider.Combine(_fileProvider.MapPath("~/wwwroot"), "robots.additions.txt");
            var content = string.Join(Environment.NewLine, AiOptimizerDefaults.DefaultAiRobotsRules) + Environment.NewLine;
            if (!_fileProvider.FileExists(additionsFilePath))
            {
                await _fileProvider.WriteAllTextAsync(additionsFilePath, content, Encoding.UTF8);
            }
            else
            {
                var existing = await _fileProvider.ReadAllTextAsync(additionsFilePath, Encoding.UTF8);
                if (!existing.Contains("GPTBot"))
                {
                    await _fileProvider.WriteAllTextAsync(additionsFilePath, existing + Environment.NewLine + content, Encoding.UTF8);
                }
            }
        }
        catch
        {
            // Ignore file system write errors if permissions are restricted
        }

        await base.InstallAsync();
    }

    /// <summary>
    /// Uninstall the plugin
    /// </summary>
    public override async Task UninstallAsync()
    {
        // 1. Delete settings
        await _settingService.DeleteSettingAsync<AiOptimizerSettings>();

        // 2. Clean up robots additions rules
        var robotsSettings = await _settingService.LoadSettingAsync<RobotsTxtSettings>();
        var modified = robotsSettings.AdditionsRules.RemoveAll(r =>
            AiOptimizerDefaults.DefaultAiRobotsRules.Contains(r) ||
            r.Contains(AiOptimizerDefaults.RobotsAdditionMarker));

        if (modified > 0)
        {
            await _settingService.SaveSettingAsync(robotsSettings, s => s.AdditionsRules);
        }

        await base.UninstallAsync();
    }
}
