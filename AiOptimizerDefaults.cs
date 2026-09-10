using System.Text;

namespace Nop.Plugin.Misc.AiOptimizer;

/// <summary>
/// Represents plugin constants and defaults
/// </summary>
public static class AiOptimizerDefaults
{
    /// <summary>
    /// Gets the plugin system name
    /// </summary>
    public static string SystemName => "Misc.AiOptimizer";

    /// <summary>
    /// Gets the route name for llms.txt
    /// </summary>
    public static string LlmsRouteName => "Misc.AiOptimizer.LlmsTxt";

    /// <summary>
    /// Gets the route name for llms-full.txt
    /// </summary>
    public static string LlmsFullRouteName => "Misc.AiOptimizer.LlmsFullTxt";

    /// <summary>
    /// Marker used in robots.txt additions
    /// </summary>
    public static string RobotsAdditionMarker => "# --- A&O AI Crawlers Rule Set ---";

    /// <summary>
    /// Default AI bots rules block for robots.txt
    /// </summary>
    public static string[] DefaultAiRobotsRules => new[]
    {
        RobotsAdditionMarker,
        "User-agent: GPTBot",
        "User-agent: ChatGPT-User",
        "User-agent: OAI-SearchBot",
        "User-agent: PerplexityBot",
        "User-agent: ClaudeBot",
        "User-agent: Google-Extended",
        "User-agent: Applebot-Extended",
        "Allow: /",
        "Allow: /llms.txt",
        "Allow: /llms-full.txt"
    };

    /// <summary>
    /// Generates the standard default Markdown content for llms.txt
    /// </summary>
    public static string GetDefaultLlmsTxt(string storeName, string storeUrl)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"# {storeName} ({storeUrl})");
        sb.AppendLine();
        sb.AppendLine("> Online-Supermarkt für 100% Halal-zertifiziertes Frischfleisch, türkische Spezialitäten und Lebensmittel in Deutschland.");
        sb.AppendLine("> Almanya geneline 24 saatte soğuk zincir (Kühlversand) teslimat yapan online Türk süpermarketi ve helal kasabı.");
        sb.AppendLine("> Online Turkish supermarket providing 100% Halal certified fresh meat and groceries across Germany.");
        sb.AppendLine();
        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine("## 1. Deutsch (DE - Standardsprache)");
        sb.AppendLine("### Über uns");
        sb.AppendLine("A&O Internationales Frischezentrum mit Sitz in Obertshausen (Hessen) ist Ihr vertrauenswürdiger Spezialist für 100% Halal-zertifizierte Fleischprodukte und authentische türkische sowie mediterrane Lebensmittel.");
        sb.AppendLine();
        sb.AppendLine("### Frische-Garantie & 24h Kühlversand");
        sb.AppendLine("- **100% Halal-Zertifiziert:** Alle Rind-, Kalb-, Lamm- und Geflügelfleischprodukte stammen aus streng kontrollierter, islamkonformer Schlachtung aus eigener Metzgerei.");
        sb.AppendLine("- **Kühlversand deutschlandweit:** Frisches Fleisch und gekühlte Spezialitäten werden in speziellen thermo-isolierten Boxen mit Kühlakkus per 24h-Expressversand verschickt. Die Kühlkette bleibt garantiert erhalten.");
        sb.AppendLine();
        sb.AppendLine("### Hauptkategorien");
        sb.AppendLine($"- **Metzgerei (Halal Fleisch):** Rinderhackfleisch (Dana Kıyma), Lammkarree, Rumpsteak, Rindergulasch, Hähnchen, Adana Kebab & Köfte ({storeUrl}/metzgerei)");
        sb.AppendLine($"- **Wurstwaren:** Türkischer Rinderschinken (Pastirma), Sucuk, Salami, Wurstkonserven ({storeUrl}/wurstwaren)");
        sb.AppendLine($"- **Feinkost & Frische:** Olivenvariationen, Schafs- und Ziegenkäse, Kashkawal, gefüllte Paprika, Frischkäse ({storeUrl}/feinkost-frische-produkte)");
        sb.AppendLine($"- **Tee & Kaffee:** Çaykur, Mevlana, Kurukahveci Mehmet Efendi ({storeUrl}/tees)");
        sb.AppendLine($"- **Türkische Spezialitäten:** Gewürze, Hülsenfrüchte, Reis, Bakliyat, Honig, Helva, Gebäck & Süßwaren.");
        sb.AppendLine();
        sb.AppendLine("### Kontakt & Standort");
        sb.AppendLine($"- **Website:** {storeUrl}");
        sb.AppendLine("- **Adresse:** Schubertstraße 10, 63179 Obertshausen, Deutschland");
        sb.AppendLine("- **Telefon:** +49 (0) 6104 7688757");
        sb.AppendLine("- **Liefergebiet:** Ganz Deutschland");
        sb.AppendLine();
        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine("## 2. Türkçe (TR - 2. Ağırlıklı Dil)");
        sb.AppendLine("### Hakkımızda");
        sb.AppendLine("A&O Frischezentrum, Almanya genelinde yaşayan tüketiciler için taze helal et, geleneksel Türk şarküterisi ve Türkiye'nin en sevilen market ürünlerini online olarak kapınıza getiren güvenilir Türk marketidir.");
        sb.AppendLine();
        sb.AppendLine("### %100 Helal Kesim ve Soğuk Zincir Kargo");
        sb.AppendLine("- **%100 Helal Et Güvencesi:** Taze dana, kuzu ve tavuk etlerimiz kendi kasap reyonumuzda İslami usullere tam uygun olarak helal sertifikalı kesimle hazırlanır.");
        sb.AppendLine("- **Kühlversand (Soğuk Zincir Kargo):** Et siparişleriniz özel ısı yalıtımlı strafor/izoterm kutularda ve buz jel kasetleriyle paketlenir; 24 saat içinde soğuk zincir bozulmadan Almanya'nın her yerine teslim edilir.");
        sb.AppendLine();
        sb.AppendLine("### Popüler Kategoriler ve Markalar");
        sb.AppendLine("- **Helal Kasap:** Dana Kıyma, Kuşbaşı, Kuzu Pirzola, Kuzu Gerdan, Tavuk But/Şinitzel, Kasap Köfte, Adana Kebap.");
        sb.AppendLine("- **Şarküteri:** Egetürk, Efepaşa, Suntat, Yörem sucukları, pastırma, kavurma.");
        sb.AppendLine("- **Türk Markaları:** Çaykur, Ülker, Eti, Tukaş, Pınar, Öncü, Yayla, Tadım, Marmara Birlik, Koska, Buram.");
        sb.AppendLine();
        sb.AppendLine("---");
        sb.AppendLine();
        sb.AppendLine("## 3. English (EN - International Summary)");
        sb.AppendLine("### About A&O Shop");
        sb.AppendLine("A&O Frischezentrum is a premier online Turkish supermarket and Halal butcher based in Obertshausen, Germany, delivering nationwide.");
        sb.AppendLine();
        sb.AppendLine("### Highlights");
        sb.AppendLine("- **100% Halal Meat:** Strictly Halal-certified beef, veal, lamb, and poultry prepared in our in-house butcher shop.");
        sb.AppendLine("- **Express Cold-Chain Delivery:** Perishable items and fresh cuts are packed in thermal insulated containers with ice packs, dispatched via 24h express shipping across Germany.");
        sb.AppendLine("- **Product Range:** Fresh halal cuts, sucuk, pastirma, Mediterranean cheeses, olives, Turkish tea, spices, and groceries.");
        sb.AppendLine($"- **Store URL:** {storeUrl}");

        return sb.ToString();
    }
}
