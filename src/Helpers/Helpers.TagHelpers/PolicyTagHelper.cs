using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "policy-name,policy-value")]
    public class PolicyTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PolicyTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string PolicyName { get; set; }
        public string PolicyValue { get; set; }

        public override Task ProcessAsync(
            TagHelperContext context, TagHelperOutput output)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                if (!ClaimcHelper.IsValid(_httpContextAccessor.HttpContext, PolicyValue, PolicyName))
                {
                    output.Content.Clear();
                }
            }

            return base.ProcessAsync(context, output);
        }
    }
}
