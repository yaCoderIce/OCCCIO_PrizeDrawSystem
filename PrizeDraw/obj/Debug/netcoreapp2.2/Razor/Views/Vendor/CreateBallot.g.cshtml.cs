#pragma checksum "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fca6fe4a70730bfbf44ce4d4f6935d1c63c28e34"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fca6fe4a70730bfbf44ce4d4f6935d1c63c28e34", @"/Views/Vendor/CreateBallot.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bcb46126052d945fa0f6ce90334124fa31ea674", @"/Views/_ViewImports.cshtml")]
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
#line 1 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
  
    ViewData["Title"] = "ballot";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(126, 29, true);
            WriteLiteral("\r\n<div id=\"topMessage\">\r\n    ");
            EndContext();
            BeginContext(155, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fca6fe4a70730bfbf44ce4d4f6935d1c63c28e346195", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 8 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
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
            BeginContext(224, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 9 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
     if (!string.IsNullOrWhiteSpace(Model.ScannedAttendeeName))
    {

#line default
#line hidden
            BeginContext(298, 35, true);
            WriteLiteral("        <p class=\"h2 text-success\">");
            EndContext();
            BeginContext(334, 25, false);
#line 11 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
                              Write(Model.ScannedAttendeeName);

#line default
#line hidden
            EndContext();
            BeginContext(359, 28, true);
            WriteLiteral(" Prize Ballots Created</p>\r\n");
            EndContext();
#line 12 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
    }

#line default
#line hidden
            BeginContext(394, 310, true);
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
            BeginContext(704, 535, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fca6fe4a70730bfbf44ce4d4f6935d1c63c28e349213", async() => {
                BeginContext(791, 441, true);
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
            BeginContext(1239, 266, true);
            WriteLiteral(@"
        </div>
    </div>
</div>
<br />
<div class=""row"">
    <div class=""offset-2 col-lg-8"">
        <h3 class=""h1"">Stats</h3>
        <table class=""table"" id=""statsTable"">
            <tr>
                <th>Scanned Attendees</th>
                <td>");
            EndContext();
            BeginContext(1506, 22, false);
#line 43 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
               Write(Model.AttendeesScanned);

#line default
#line hidden
            EndContext();
            BeginContext(1528, 106, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Total Attendees</th>\r\n                <td>");
            EndContext();
            BeginContext(1635, 20, false);
#line 47 "C:\Users\Dev\Documents\OCCCIO_PrizeDrawSystem\PrizeDraw\Views\Vendor\CreateBallot.cshtml"
               Write(Model.TotalAttendees);

#line default
#line hidden
            EndContext();
            BeginContext(1655, 64, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1737, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1743, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fca6fe4a70730bfbf44ce4d4f6935d1c63c28e3413152", async() => {
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
                BeginContext(1787, 559, true);
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
            BeginContext(2349, 2, true);
            WriteLiteral("\r\n");
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