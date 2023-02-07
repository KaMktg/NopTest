using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.BookDiscount.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        /// <summary>
        /// Message text
        /// </summary>
        [NopResourceDisplayName("Plugins.Widgets.BookDiscount.Fields.Messages")]
        public string Messages { get; set; }
    }
}
