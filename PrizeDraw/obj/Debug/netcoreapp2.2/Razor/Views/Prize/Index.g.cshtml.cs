#pragma checksum "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "409a751da994de2ca0bf5e0497062464d436491f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prize_Index), @"mvc.1.0.view", @"/Views/Prize/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Prize/Index.cshtml", typeof(AspNetCore.Views_Prize_Index))]
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
#line 1 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\_ViewImports.cshtml"
using PrizeDraw;

#line default
#line hidden
#line 2 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\_ViewImports.cshtml"
using PrizeDraw.Models;

#line default
#line hidden
#line 3 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\_ViewImports.cshtml"
using PrizeDraw.DataLayer.Model.Identity;

#line default
#line hidden
#line 4 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
using PrizeDraw.DataLayer.Model;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"409a751da994de2ca0bf5e0497062464d436491f", @"/Views/Prize/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bcb46126052d945fa0f6ce90334124fa31ea674", @"/Views/_ViewImports.cshtml")]
    public class Views_Prize_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PrizeIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary floatLeft"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Prize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GenerateWinners", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(62, 83, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        <h4>Prizes</h4>\r\n        ");
            EndContext();
            BeginContext(145, 88, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "409a751da994de2ca0bf5e0497062464d436491f6226", async() => {
                BeginContext(225, 4, true);
                WriteLiteral(" Add");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(233, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(243, 185, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "409a751da994de2ca0bf5e0497062464d436491f7892", async() => {
                BeginContext(315, 106, true);
                WriteLiteral("\r\n            <input class=\"btn btn-primary floatLeft\" value=\"Generate Winners\" type=\"submit\" />\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(428, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 11 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
         if(Model.NumberOfWinnersDrawn.HasValue)
        {

#line default
#line hidden
            BeginContext(491, 18, true);
            WriteLiteral("            <span>");
            EndContext();
            BeginContext(510, 26, false);
#line 13 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
             Write(Model.NumberOfWinnersDrawn);

#line default
#line hidden
            EndContext();
            BeginContext(536, 23, true);
            WriteLiteral(" Winners Drawn</span>\r\n");
            EndContext();
#line 14 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(570, 476, true);
            WriteLiteral(@"        <br />
        <hr />
        <div id=""vendorsManage"" class=""text-left"">
            <table>
                <thead>
                    <tr>
                        <th>Image</th>
                        <th>Name</th>
                        <th>Sponsor</th>
                        <th>Available</th>
                        <th>Winners</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 30 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                     foreach (PrizeModel prize in Model.Prizes)
                    {

#line default
#line hidden
            BeginContext(1134, 64, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n");
            EndContext();
#line 34 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                                 if (prize.Image != null)
                                {

#line default
#line hidden
            BeginContext(1292, 40, true);
            WriteLiteral("                                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1332, "\"", 1399, 2);
            WriteAttributeValue("", 1338, "data:image;base64,", 1338, 18, true);
#line 36 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
WriteAttributeValue("", 1356, System.Convert.ToBase64String(prize.Image), 1356, 43, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1400, 30, true);
            WriteLiteral(" width=\"100\" height=\"100\" />\r\n");
            EndContext();
#line 37 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(1465, 67, true);
            WriteLiteral("                            </td>\r\n                            <td>");
            EndContext();
            BeginContext(1533, 10, false);
#line 39 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                           Write(prize.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1543, 41, true);
            WriteLiteral("</td>\r\n                            <td>\r\n");
            EndContext();
#line 41 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                                 if (!string.IsNullOrWhiteSpace(prize.SponsorName))
                                {
                                    

#line default
#line hidden
            BeginContext(1741, 17, false);
#line 43 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                               Write(prize.SponsorName);

#line default
#line hidden
            EndContext();
#line 43 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                                                      ;
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(1869, 54, true);
            WriteLiteral("                                    <span>N/A</span>\r\n");
            EndContext();
#line 48 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(1958, 59, true);
            WriteLiteral("                        </td>\r\n                        <td>");
            EndContext();
            BeginContext(2018, 21, false);
#line 50 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                       Write(prize.NumberAvailable);

#line default
#line hidden
            EndContext();
            BeginContext(2039, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2075, 21, false);
#line 51 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                       Write(prize.NumberOfWinners);

#line default
#line hidden
            EndContext();
            BeginContext(2096, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2131, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "409a751da994de2ca0bf5e0497062464d436491f15520", async() => {
                BeginContext(2203, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                                                                             WriteLiteral(prize.Id);

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
            BeginContext(2214, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(2217, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "409a751da994de2ca0bf5e0497062464d436491f18095", async() => {
                BeginContext(2286, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 52 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                                                                                                                                                                WriteLiteral(prize.Id);

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
            BeginContext(2294, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 54 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Prize\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2347, 102, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n            <hr />\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PrizeIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
