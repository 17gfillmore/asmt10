using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace asmt10.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "set-up-correctly")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlInfo;

        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        public bool SetUpCorrectly { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder finishedTag = new TagBuilder("div");
            TagBuilder individualTag = new TagBuilder("a");

            individualTag.Attributes["href"] = "/Grace";
            individualTag.InnerHtml.AppendHtml("Gucci");

            finishedTag.InnerHtml.AppendHtml(individualTag);

            output.Content.AppendHtml(finishedTag.InnerHtml);
        }
    }
}
