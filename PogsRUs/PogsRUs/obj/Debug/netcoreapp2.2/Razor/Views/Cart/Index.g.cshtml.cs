#pragma checksum "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb3bedc2e435afd6f56e5bd2a4bb51e6f7098425"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/Index.cshtml", typeof(AspNetCore.Views_Cart_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb3bedc2e435afd6f56e5bd2a4bb51e6f7098425", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PogsRUs.Models.CartProduct>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Summary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateCartProductQuantity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveCartProduct", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Cart";
    Layout = "_Layout";

#line default
#line hidden
            BeginContext(106, 43, true);
            WriteLiteral("\r\n<div>\r\n    <h1>Shopping Cart Items</h1>\r\n");
            EndContext();
#line 9 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
     if (Model.Count() > 0)
    {

#line default
#line hidden
            BeginContext(185, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(193, 234, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb3bedc2e435afd6f56e5bd2a4bb51e6f70984255084", async() => {
                BeginContext(246, 48, true);
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"userID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 294, "\"", 321, 1);
#line 12 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
WriteAttributeValue("", 302, User.Identity.Name, 302, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(322, 98, true);
                WriteLiteral(" method=\"post\" />\r\n\r\n            <button id=\"button-new\" type=\"submit\">Checkout</button>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(427, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 18 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
         foreach (var cartProduct in Model)
        {


#line default
#line hidden
            BeginContext(499, 16, true);
            WriteLiteral("            <h3>");
            EndContext();
            BeginContext(516, 16, false);
#line 21 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
           Write(cartProduct.Name);

#line default
#line hidden
            EndContext();
            BeginContext(532, 19, true);
            WriteLiteral("</h3>\r\n            ");
            EndContext();
            BeginContext(551, 467, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb3bedc2e435afd6f56e5bd2a4bb51e6f70984258150", async() => {
                BeginContext(618, 52, true);
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"userID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 670, "\"", 697, 1);
#line 23 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
WriteAttributeValue("", 678, User.Identity.Name, 678, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(698, 72, true);
                WriteLiteral(" method=\"post\" />\r\n                <input type=\"hidden\" name=\"productID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 770, "\"", 800, 1);
#line 24 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
WriteAttributeValue("", 778, cartProduct.ProductID, 778, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(801, 71, true);
                WriteLiteral(" method=\"post\" />\r\n                <input type=\"number\" name=\"quantity\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 872, "\"", 901, 1);
#line 25 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
WriteAttributeValue("", 880, cartProduct.Quantity, 880, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(902, 109, true);
                WriteLiteral(" method=\"post\" />\r\n\r\n                <button id=\"button\" type=\"submit\">Update Quantity</button>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1018, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(1032, 359, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb3bedc2e435afd6f56e5bd2a4bb51e6f709842511601", async() => {
                BeginContext(1091, 52, true);
                WriteLiteral("\r\n                <input type=\"hidden\" name=\"userID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1143, "\"", 1170, 1);
#line 30 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1151, User.Identity.Name, 1151, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1171, 72, true);
                WriteLiteral(" method=\"post\" />\r\n                <input type=\"hidden\" name=\"productID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1243, "\"", 1273, 1);
#line 31 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1251, cartProduct.ProductID, 1251, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1274, 110, true);
                WriteLiteral(" method=\"post\" />\r\n\r\n                <button id=\"button\" type=\"submit\">Remove from Cart</button>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1391, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 35 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
        }

#line default
#line hidden
#line 35 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
         
    }
    else
    {

#line default
#line hidden
            BeginContext(1428, 36, true);
            WriteLiteral("        <p>Shopping Cart Empty</p>\r\n");
            EndContext();
#line 40 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Cart\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1471, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PogsRUs.Models.CartProduct>> Html { get; private set; }
    }
}
#pragma warning restore 1591