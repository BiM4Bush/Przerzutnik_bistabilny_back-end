#pragma checksum "C:\Users\sebak\source\repos\BiM4Bush\Przerzutnik_bistabilny_back-end\.NET\Kanban\Kanban\Views\Kanbans\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05511afa00406484e2a12643fbd8d5bab1b3a291"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Kanbans_Details), @"mvc.1.0.view", @"/Views/Kanbans/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05511afa00406484e2a12643fbd8d5bab1b3a291", @"/Views/Kanbans/Details.cshtml")]
    public class Views_Kanbans_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Kanban.Models.KanbanBoard>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\sebak\source\repos\BiM4Bush\Przerzutnik_bistabilny_back-end\.NET\Kanban\Kanban\Views\Kanbans\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Kanban</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\sebak\source\repos\BiM4Bush\Przerzutnik_bistabilny_back-end\.NET\Kanban\Kanban\Views\Kanbans\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\sebak\source\repos\BiM4Bush\Przerzutnik_bistabilny_back-end\.NET\Kanban\Kanban\Views\Kanbans\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 411, "\"", 441, 1);
#nullable restore
#line 22 "C:\Users\sebak\source\repos\BiM4Bush\Przerzutnik_bistabilny_back-end\.NET\Kanban\Kanban\Views\Kanbans\Details.cshtml"
WriteAttributeValue("", 426, Model.KanbanId, 426, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Kanban.Models.KanbanBoard> Html { get; private set; }
    }
}
#pragma warning restore 1591
