#pragma checksum "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a12bbf615345d921f3e0a4d0e8c5d71447bf799"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vendor_CreateBallot), @"mvc.1.0.view", @"/Views/Vendor/CreateBallot.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vendor/CreateBallot.cshtml", typeof(AspNetCore.Views_Vendor_CreateBallot))]
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
#line 1 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\_ViewImports.cshtml"
using PrizeDraw;

#line default
#line hidden
#line 2 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\_ViewImports.cshtml"
using PrizeDraw.Models;

#line default
#line hidden
#line 3 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\_ViewImports.cshtml"
using PrizeDraw.DataLayer.Model.Identity;

#line default
#line hidden
#line 4 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a12bbf615345d921f3e0a4d0e8c5d71447bf799", @"/Views/Vendor/CreateBallot.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5525223f73bc26a7ef89b80112d64843138ff9a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Vendor_CreateBallot : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VendorCreateBalllotViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger h2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("scannerForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateBallot", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Vendor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
  
    ViewData["Title"] = "ballot";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(121, 27, true);
            WriteLiteral("\n<div id=\"topMessage\">\n    ");
            EndContext();
            BeginContext(148, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a12bbf615345d921f3e0a4d0e8c5d71447bf7996434", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 8 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(217, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 9 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
     if (!string.IsNullOrWhiteSpace(Model.ScannedAttendeeName))
    {

#line default
#line hidden
            BeginContext(288, 35, true);
            WriteLiteral("        <p class=\"h2 text-success\">");
            EndContext();
            BeginContext(324, 25, false);
#line 11 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
                              Write(Model.ScannedAttendeeName);

#line default
#line hidden
            EndContext();
            BeginContext(349, 27, true);
            WriteLiteral(" Prize Ballots Created</p>\n");
            EndContext();
#line 12 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
    }

#line default
#line hidden
            BeginContext(382, 300, true);
            WriteLiteral(@"</div>

<div class=""row"" id=""scannerSection"">
    <div class=""col-lg-12"">
        <h1 class=""display-3"">Scan Attendee</h1>
        <br />
        <p class=""h3"">Scan attedee's badge barcode to create a prize ballot</p>
        <br />
        <p class=""h1"">Or</p>
        <div id=""ballot"">
            ");
            EndContext();
            BeginContext(682, 526, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a12bbf615345d921f3e0a4d0e8c5d71447bf7999599", async() => {
                BeginContext(769, 432, true);
                WriteLiteral(@"
                <div class=""row"">
                    <div class=""col-lg-10"">
                        <input type=""text"" id=""scannerFormId"" name=""attendeeId"" placeholder=""Attendee Barcode"" />
                    </div>
                    <div class=""col-lg-2"">
                        <input type=""submit"" id=""scannerFormBtn"" value=""Submit"" class=""btn btn-primary"" />
                    </div>
                </div>
            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
            BeginContext(1208, 255, true);
            WriteLiteral("\n        </div>\n    </div>\n</div>\n<br />\n<div class=\"row\">\n    <div class=\"offset-2 col-lg-8\">\n        <h3 class=\"h1\">Stats</h3>\n        <table class=\"table\" id=\"statsTable\">\n            <tr>\n                <th>Scanned Attendees</th>\n                <td>");
            EndContext();
            BeginContext(1464, 22, false);
#line 43 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
               Write(Model.AttendeesScanned);

#line default
#line hidden
            EndContext();
            BeginContext(1486, 102, true);
            WriteLiteral("</td>\n            </tr>\n            <tr>\n                <th>Total Attendees</th>\n                <td>");
            EndContext();
            BeginContext(1589, 20, false);
#line 47 "C:\Users\100732221\Desktop\OCCCIO_PrizeDrawSystem-master\OCCCIO_PrizeDrawSystem-master\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
               Write(Model.TotalAttendees);

#line default
#line hidden
            EndContext();
            BeginContext(1609, 59, true);
            WriteLiteral("</td>\n            </tr>\n        </table>\n    </div>\n</div>\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1686, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(1691, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6a12bbf615345d921f3e0a4d0e8c5d71447bf79913590", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1735, 538, true);
                WriteLiteral(@"
    <script>
        var scannerInput = """";

        document.addEventListener('keydown', function (event) {
            if (event.keyCode == 13) {
                $('#scannerFormId').val(scannerInput);
                $('#scannerForm').submit();
            } else {
                scannerInput += event.key;
            }
        });

        $(document).ready(function () {
            setTimeout(fadeOutMessage, 5000);
        });

        function fadeOutMessage() {
            $('#topMessage').fadeOut();
        }
    </script>
");
                EndContext();
            }
            );
            BeginContext(2275, 1, true);
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VendorCreateBalllotViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
