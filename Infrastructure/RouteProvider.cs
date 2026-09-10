using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Misc.AiOptimizer.Infrastructure;

/// <summary>
/// Registers custom routes for AI Optimizer plugin
/// </summary>
public class RouteProvider : IRouteProvider
{
    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllerRoute(
            name: AiOptimizerDefaults.LlmsRouteName,
            pattern: "llms.txt",
            defaults: new { controller = "AiOptimizer", action = "LlmsTxt" });

        endpointRouteBuilder.MapControllerRoute(
            name: AiOptimizerDefaults.LlmsFullRouteName,
            pattern: "llms-full.txt",
            defaults: new { controller = "AiOptimizer", action = "LlmsFullTxt" });
    }

    public int Priority => 100;
}
