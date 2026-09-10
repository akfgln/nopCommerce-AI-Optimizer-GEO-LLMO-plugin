# nopCommerce AI Optimizer (GEO & LLMO)

[![nopCommerce Version](https://img.shields.io/badge/nopCommerce-4.90-blue.svg)](https://www.nopcommerce.com/)
[![.NET Version](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A lightweight, zero-overhead **Generative Engine Optimization (GEO)** and **Large Language Model Optimization (LLMO)** plugin for **nopCommerce 4.90** (.NET 9).

This plugin helps modern AI search engines and agents (such as **ChatGPT / SearchGPT**, **Perplexity AI**, **Google Gemini / AI Overviews**, and **Claude**) discover, understand, and accurately recommend your online store and products.

---

## 🚀 Why AI Optimizer?

Traditional SEO optimizes for keyword rank lists in Google. **GEO (Generative Engine Optimization)** optimizes for how AI models parse, synthesize, and recommend entities to users.

Without structured AI context:
- AI models often confuse store brand names with unrelated domains or industries.
- Specific qualities (e.g., *Halal certification, regional butcheries, cold-chain refrigerated delivery, authentic Turkish/Mediterranean groceries*) are missed in AI-generated answers.
- AI crawlers encounter minified, JavaScript-heavy HTML without a lightweight semantic summary.

**`Misc.AiOptimizer`** solves this cleanly using native nopCommerce patterns.

---

## ✨ Features

- **Dynamic `/llms.txt` & `/llms-full.txt` Endpoints:**
  - Serves clean, fast Markdown directly to AI agents.
  - Pre-configured with rich store identity, product catalog highlights, shipping policies, and regional delivery details.
- **In-Admin Live Content Editor:**
  - View and customize your `/llms.txt` and `/llms-full.txt` files directly within the nopCommerce Admin area with a built-in monospace editor.
  - Instantly preview live files with one click.
- **Automated `robots.txt` AI Crawler Onboarding:**
  - Automatically permits authorized AI search bots (`GPTBot`, `ChatGPT-User`, `OAI-SearchBot`, `PerplexityBot`, `ClaudeBot`, `Google-Extended`, `Applebot-Extended`) upon installation.
  - Automatically registers `Allow: /llms.txt` without editing configuration files manually.
- **Rich Schema.org JSON-LD Structured Data:**
  - **Store Entity (`GroceryStore` / `OnlineStore`):** Injected into `<head>` with multilingual `knowsAbout`, postal address, and localized alternate brand names.
  - **Diet Enrichment (`HalalDiet`):** Injects `suitableForDiet: "https://schema.org/HalalDiet"` on product pages for religious and dietary classification in AI knowledge graphs.
  - **Instant AI Q&A (`FAQPage`):** Provides structured Q&A on certification, cold-chain shipping, and delivery zones for AI snippet answers.
- **Multilingual Out of the Box:**
  - Tailored for multilingual stores (German as default, Turkish as secondary, English as international).
- **Clean Architecture & Zero Core Modifications:**
  - Follows Ponytail minimal design: no external dependencies, no database migrations, runs entirely via nopCommerce `IWidgetPlugin` and `IRouteProvider`.

---

## 📋 Requirements

- **nopCommerce:** 4.90 or higher
- **Target Framework:** .NET 9.0
- **Supported Databases:** Any database supported by nopCommerce (SQL Server, MySQL, PostgreSQL)

---

## 🛠️ Installation

### Option 1: Visual Studio / Source Code
1. Clone or copy the plugin into your nopCommerce solution under `src/Plugins/Nop.Plugin.Misc.AiOptimizer`.
2. Add the project to your solution:
   ```bash
   dotnet sln add src/Plugins/Nop.Plugin.Misc.AiOptimizer/Nop.Plugin.Misc.AiOptimizer.csproj --solution-folder Plugins
   ```
3. Build the project:
   ```bash
   dotnet build src/Plugins/Nop.Plugin.Misc.AiOptimizer/Nop.Plugin.Misc.AiOptimizer.csproj
   ```

### Option 2: Pre-built Binary
1. Copy the build output directory `Misc.AiOptimizer` into your running nopCommerce site under `Presentation/Nop.Web/Plugins/Misc.AiOptimizer`.
2. Restart the application.

### Activation
1. Log in to your **nopCommerce Admin Area**.
2. Navigate to **Configuration > Local Plugins**.
3. Locate **AI Optimizer (GEO & LLMO)** in the list and click **Install**.
4. Click **Restart application** in the top right corner.

---

## ⚙️ Configuration

Navigate to **Configuration > Local Plugins > AI Optimizer > Configure** (or `/Admin/AiOptimizerAdmin/Configure`):

1. **Live AI & LLM Endpoints:** Test your live endpoints via direct links:
   - `https://yourstore.com/llms.txt`
   - `https://yourstore.com/llms-full.txt`
   - `https://yourstore.com/robots.txt`
2. **Feature Toggles:**
   - Toggle `llms.txt` endpoints on or off.
   - Toggle `GroceryStore` homepage JSON-LD.
   - Toggle `HalalDiet` product schema.
   - Toggle `FAQPage` schema.
3. **Markdown Editor:**
   - Modify the default store summary, product categories, or certifications.
   - Click **Save** to immediately serve the updated content to AI bots.

---

## 📁 Project Structure

```
Nop.Plugin.Misc.AiOptimizer/
├── Components/
│   └── AiOptimizerHeadViewComponent.cs  # Injects JSON-LD into head_html_tag
├── Controllers/
│   ├── AiOptimizerController.cs         # Serves /llms.txt and /llms-full.txt
│   └── AiOptimizerAdminController.cs    # Admin configuration controller
├── Infrastructure/
│   └── RouteProvider.cs                 # Maps /llms.txt and /llms-full.txt
├── Models/
│   ├── AiOptimizerModel.cs              # View model for head injection
│   └── ConfigurationModel.cs            # Admin configuration model
├── Views/
│   ├── Configure.cshtml                 # Admin configuration page
│   ├── HeadTag.cshtml                   # Razor JSON-LD templates
│   └── _ViewImports.cshtml
├── AiOptimizerDefaults.cs               # Constants, default bots, and markdown
├── AiOptimizerPlugin.cs                 # Plugin entry, install/uninstall lifecycle
├── AiOptimizerSettings.cs               # Strongly-typed ISettings
├── LICENSE                              # MIT License
├── plugin.json                          # Plugin manifest
└── README.md                            # Documentation
```

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
