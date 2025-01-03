using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;
using Services.Contracts;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes ="products")]
    public class LastestProductTagHelper : TagHelper
    {
        private readonly IServiceManager _manager;
        public  LastestProductTagHelper(IServiceManager manager)
        {
            _manager = manager;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder div = new TagBuilder("div");
            div.Attributes.Add("class","my-3");

            TagBuilder h6 = new TagBuilder("h6");
            h6.Attributes.Add("class","lead");

            TagBuilder icon = new TagBuilder("i");
            icon.Attributes.Add("class","fa fa-box text secondary");

            h6.InnerHtml.AppendHtml(icon);
            h6.InnerHtml.AppendHtml("Lastest Products");

            div.InnerHtml.AppendHtml(h6);
            output.Content.AppendHtml(div);

        }
       

    }
}