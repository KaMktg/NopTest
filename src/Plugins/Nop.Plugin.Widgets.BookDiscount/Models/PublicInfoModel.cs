using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.BookDiscount.Models
{
    public record PublicInfoModel : BaseNopModel
    {
        /// <summary>
        /// Message text
        /// </summary>
        public string Message { get; set; }
    }
}
