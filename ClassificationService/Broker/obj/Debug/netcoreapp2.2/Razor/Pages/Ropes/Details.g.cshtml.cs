#pragma checksum "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7262a36628345d234fa10822d9a9fdb64cd62ff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Broker.Pages.Ropes.Pages_Ropes_Details), @"mvc.1.0.razor-page", @"/Pages/Ropes/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Ropes/Details.cshtml", typeof(Broker.Pages.Ropes.Pages_Ropes_Details), null)]
namespace Broker.Pages.Ropes
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\_ViewImports.cshtml"
using Broker;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7262a36628345d234fa10822d9a9fdb64cd62ff", @"/Pages/Ropes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"206e7b24cf9dcd72f320c6c3cd5c36b83bd3e25c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Ropes_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(92, 125, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Rope</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(218, 47, false);
#line 15 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Rope.RopeID));

#line default
#line hidden
            EndContext();
            BeginContext(265, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(327, 46, false);
#line 18 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Rope.Image));

#line default
#line hidden
            EndContext();
            BeginContext(373, 60, true);
            WriteLiteral("\r\n        </dt>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(434, 44, false);
#line 21 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Rope.Tag));

#line default
#line hidden
            EndContext();
            BeginContext(478, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(540, 40, false);
#line 24 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Rope.Tag));

#line default
#line hidden
            EndContext();
            BeginContext(580, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(641, 52, false);
#line 27 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Rope.CaptureDate));

#line default
#line hidden
            EndContext();
            BeginContext(693, 61, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(755, 48, false);
#line 30 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Rope.CaptureDate));

#line default
#line hidden
            EndContext();
            BeginContext(803, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dd class=\"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(864, 43, false);
#line 33 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
       Write(Html.DisplayFor(model => model.Rope.ShipID));

#line default
#line hidden
            EndContext();
            BeginContext(907, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(954, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7262a36628345d234fa10822d9a9fdb64cd62ff7283", async() => {
                BeginContext(1009, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 38 "C:\Users\maros\Documents\GitHub\challenge-server\ClassificationService\Broker\Pages\Ropes\Details.cshtml"
                           WriteLiteral(Model.Rope.RopeID);

#line default
#line hidden
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
            EndContext();
            BeginContext(1017, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1025, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7262a36628345d234fa10822d9a9fdb64cd62ff9636", async() => {
                BeginContext(1047, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1063, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Broker.Pages.Ropes.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Broker.Pages.Ropes.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Broker.Pages.Ropes.DetailsModel>)PageContext?.ViewData;
        public Broker.Pages.Ropes.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
