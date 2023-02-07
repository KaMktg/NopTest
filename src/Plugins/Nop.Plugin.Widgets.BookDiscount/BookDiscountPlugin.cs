using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Widgets.BookDiscount.Components;
using Nop.Plugin.Widgets.BookDiscount.Models;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;

namespace Nop.Plugin.Widgets.BookDiscount
{
    public class BookDiscountPlugin : BasePlugin, IWidgetPlugin
    {
        private const string WidgetZonesName = "BookDiscount";
        private const string StoreLocationRoute = "Admin/BookDiscount/Configure";

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        public BookDiscountPlugin(IWebHelper webHelper, ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the widget zones
        /// </returns>
        public Task<IList<string>> GetWidgetZonesAsync() =>
            Task.FromResult<IList<string>>(new List<string> { WidgetZonesName });

        /// <summary>
        /// Gets a type of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component type</returns>
        public Type GetWidgetViewComponent(string widgetZone) => typeof(BookDiscountViewComponent);

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl() => $"{_webHelper.GetStoreLocation()}{StoreLocationRoute}";

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.BookDiscount.Fields.Messages"] = nameof(ConfigurationModel.Messages)
            });

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.BookDiscount.Fields.Messages");

            await base.UninstallAsync();
        }
    }
}