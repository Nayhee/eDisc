#pragma checksum "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70a313a5391fb957de220d3216d2687a9a46e264"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Disc_Details), @"mvc.1.0.view", @"/Views/Disc/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\_ViewImports.cshtml"
using eDISC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\_ViewImports.cshtml"
using eDISC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70a313a5391fb957de220d3216d2687a9a46e264", @"/Views/Disc/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90098e45c9e423c90b71ccf01bbd814dcd3ffa97", @"/Views/_ViewImports.cshtml")]
    public class Views_Disc_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eDISC.Models.Disc>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <div class=\"card\">\r\n        <img class=\"card-img-top\" style=\"max-width: 26vw\"");
            BeginWriteAttribute("src", " src=\"", 156, "\"", 177, 1);
#nullable restore
#line 9 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
WriteAttributeValue("", 162, Model.ImageUrl, 162, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\" />\r\n        \r\n        <div class=\"card-body\">\r\n            <h2 class=\"card-title\">");
#nullable restore
#line 12 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                              Write(Model.NamePlastic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n            <p class=\"card-text\">");
#nullable restore
#line 14 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                            Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n           \r\n            <p class=\"card-text\">Flight Numbers:</p>\r\n            <div class=\"flightNumsContainer\">\r\n                    <div class=\"flightNum\">");
#nullable restore
#line 18 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                      Write(Model.Speed);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"flightNum\">");
#nullable restore
#line 19 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                      Write(Model.Glide);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"flightNum\">");
#nullable restore
#line 20 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                      Write(Model.Turn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    <div class=\"flightNum\">");
#nullable restore
#line 21 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                      Write(Model.Fade);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                </div>\r\n\r\n            <p class=\"card-text\">Condition: ");
#nullable restore
#line 24 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                       Write(Model.Condition);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            <p class=\"card-text\">Categories: ");
#nullable restore
#line 25 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                        Write(Model.DisplayTags);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"card-text\">Weight: ");
#nullable restore
#line 26 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                    Write(Model.Weight);

#line default
#line hidden
#nullable disable
            WriteLiteral(" g</p>\r\n       \r\n            <p class=\"card-text\">Price: $");
#nullable restore
#line 28 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                    Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70a313a5391fb957de220d3216d2687a9a46e2647751", async() => {
                WriteLiteral("ADD TO CART");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
                                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    \r\n<br />\r\n    \r\n<div>\r\n    ");
#nullable restore
#line 36 "C:\Users\natha\workspace\VS\eDISC\eDISC\Views\Disc\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id= Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70a313a5391fb957de220d3216d2687a9a46e26410443", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eDISC.Models.Disc> Html { get; private set; }
    }
}
#pragma warning restore 1591
