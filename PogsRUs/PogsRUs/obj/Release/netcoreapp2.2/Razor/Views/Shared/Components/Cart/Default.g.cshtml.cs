#pragma checksum "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb2915338e8f0bd4216f51985cb21a008434b006"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Cart_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Cart/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Cart/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Cart_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb2915338e8f0bd4216f51985cb21a008434b006", @"/Views/Shared/Components/Cart/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Cart_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PogsRUs.Models.CartProduct>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 43, true);
            WriteLiteral("\r\n<div>\r\n    <h1>Shopping Cart Items</h1>\r\n");
            EndContext();
#line 5 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml"
     if (Model != null)
    {
        

#line default
#line hidden
#line 7 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml"
         foreach (var cartProduct in Model)
        {

#line default
#line hidden
            BeginContext(172, 16, true);
            WriteLiteral("            <h3>");
            EndContext();
            BeginContext(189, 16, false);
#line 9 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml"
           Write(cartProduct.Name);

#line default
#line hidden
            EndContext();
            BeginContext(205, 33, true);
            WriteLiteral("</h3>\r\n            <p>Quantity = ");
            EndContext();
            BeginContext(239, 20, false);
#line 10 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml"
                     Write(cartProduct.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(259, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 11 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml"
        }

#line default
#line hidden
#line 11 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml"
         
    }
    else
    {

#line default
#line hidden
            BeginContext(300, 36, true);
            WriteLiteral("        <p>Shopping Cart Empty</p>\r\n");
            EndContext();
#line 16 "C:\Users\ntibb\codefellows\401\Ecom\PogsRUs\PogsRUs\Views\Shared\Components\Cart\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(343, 10, true);
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
