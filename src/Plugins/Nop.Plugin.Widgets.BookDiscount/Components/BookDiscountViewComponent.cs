using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Nop.Web.Framework.Components;
using Nop.Core;
using Nop.Services.Configuration;
using Nop.Plugin.Widgets.BookDiscount.Models;

namespace Nop.Plugin.Widgets.BookDiscount.Components
{
    public class BookDiscountViewComponent : NopViewComponent
    {
        private readonly IStoreContext _storeContext;
        private readonly ISettingService _settingService;

        public BookDiscountViewComponent(IStoreContext storeContext, ISettingService settingService)
        {
            _storeContext = storeContext;
            _settingService = settingService;
        }

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <param name="additionalData">Additional data</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the view component result
        /// </returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var store = await _storeContext.GetCurrentStoreAsync();
            var settings = await _settingService.LoadSettingAsync<BookDiscountSettings>(store.Id);


            return View("~/Plugins/Widgets.BookDiscount/Views/PublicInfo.cshtml", new PublicInfoModel
            {
                Message = settings.Messages
            });
        }

        #endregion
    }
}
