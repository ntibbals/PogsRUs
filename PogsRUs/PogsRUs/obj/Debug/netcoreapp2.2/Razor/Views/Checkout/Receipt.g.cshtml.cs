#pragma checksum "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2268c30f5d684246aa028643c54ee34616cb7516"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Checkout_Receipt), @"mvc.1.0.view", @"/Views/Checkout/Receipt.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Checkout/Receipt.cshtml", typeof(AspNetCore.Views_Checkout_Receipt))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2268c30f5d684246aa028643c54ee34616cb7516", @"/Views/Checkout/Receipt.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Checkout_Receipt : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PogsRUs.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("button-new"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
  
    ViewData["Title"] = "Receipt";
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(97, 90, true);
            WriteLiteral("\r\n<h1>Order Summary</h1>\r\n\r\n<div class=\"container\">\r\n\r\n    <h3> Total Products Purchased= ");
            EndContext();
            BeginContext(188, 29, false);
#line 11 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
                              Write(Model.PurchasedProducts.Count);

#line default
#line hidden
            EndContext();
            BeginContext(217, 9, true);
            WriteLiteral("</h3>\r\n\r\n");
            EndContext();
#line 13 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
     foreach (var product in Model.PurchasedProducts)
    {

#line default
#line hidden
            BeginContext(288, 31, true);
            WriteLiteral("        <div>\r\n            <h3>");
            EndContext();
            BeginContext(320, 12, false);
#line 16 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
           Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(332, 64, true);
            WriteLiteral("</h3>\r\n        </div>\r\n        <div>\r\n            <p>Quantity = ");
            EndContext();
            BeginContext(397, 16, false);
#line 19 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
                     Write(product.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(413, 77, true);
            WriteLiteral("</p>\r\n        </div>\r\n        <div>\r\n            <p>Total Price of Product = ");
            EndContext();
            BeginContext(491, 18, false);
#line 22 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
                                   Write(product.TotalPrice);

#line default
#line hidden
            EndContext();
            BeginContext(509, 22, true);
            WriteLiteral("</p>\r\n        </div>\r\n");
            EndContext();
#line 24 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
    }

#line default
#line hidden
            BeginContext(538, 35, true);
            WriteLiteral("\r\n    <h3>Total Cost of Purchase = ");
            EndContext();
            BeginContext(574, 16, false);
#line 26 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Checkout\Receipt.cshtml"
                            Write(Model.TotalPrice);

#line default
#line hidden
            EndContext();
            BeginContext(590, 13, true);
            WriteLiteral("</h3>\r\n\r\n    ");
            EndContext();
            BeginContext(603, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2268c30f5d684246aa028643c54ee34616cb75166708", async() => {
                BeginContext(664, 14, true);
                WriteLiteral("Return to Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(682, 10, true);
            WriteLiteral("\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PogsRUs.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591