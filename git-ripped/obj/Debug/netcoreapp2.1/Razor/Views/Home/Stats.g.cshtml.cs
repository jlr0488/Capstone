<<<<<<< Updated upstream
#pragma checksum "C:\Users\Zachery.Chambers\Documents\Capstone\Capstone\git-ripped\Views\Home\Stats.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2daed864899c926461ecc49867825b44e0b3669b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Stats), @"mvc.1.0.view", @"/Views/Home/Stats.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Stats.cshtml", typeof(AspNetCore.Views_Home_Stats))]
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
#line 1 "C:\Users\Zachery.Chambers\Documents\Capstone\Capstone\git-ripped\Views\_ViewImports.cshtml"
using git_ripped;

#line default
#line hidden
#line 2 "C:\Users\Zachery.Chambers\Documents\Capstone\Capstone\git-ripped\Views\_ViewImports.cshtml"
using git_ripped.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2daed864899c926461ecc49867825b44e0b3669b", @"/Views/Home/Stats.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"136feb6ed5067285e18983ecff911ab0f5095069", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Stats : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/StyleSheet1.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Zachery.Chambers\Documents\Capstone\Capstone\git-ripped\Views\Home\Stats.cshtml"
  
	ViewData["Title"] = "Stats";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(82, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "480bc8a275b04f92a5c42e116eb23dea", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(136, 2150, true);
            WriteLiteral(@"

<div ng-controller=""StatsCtrl"" class=""container"" ng-cloak>

    <div ng-if=""loggedIn==false"" class=""alert alert-warning"" ng-cloak >
        <strong>Oops!</strong> Sign in to view your stats.
    </div>

    <h1 class=""text-center"">Stats</h1>
    <p class=""text-center"">
        Here you will find a summary of your current statistics.
    </p>

    <div class=""row"">
        <div class=""col-md-4"">
            <div class=""single-stat"" id=""vitals"">
                <h2 align=""center"">Git Vitals</h2>
                <center><i class=""fas fa-weight fa-5x""></i></center>
                <h4>Height:</h4>
                <h4>Weight:</h4>
                <h4>Age:</h4>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""single-stat"" id=""gitstats"">
                <h2 align=""center"">Git Stats</h2>
                <center><i class=""fas fa-pen-square fa-5x""></i></center>
                <h4>Workouts Completed:</h4>
                <h4>Goal Streak:</h4>
      ");
            WriteLiteral(@"          <h4>Record Breaks:</h4>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""single-stat"" id=""records"">
                <h2 align=""center"">Git Records</h2>
                <center><i class=""fas fa-dumbbell fa-5x""></i></center>
                <h4 align=""center"" ng-if=""max1Avail==false"">No Bests Recorded Yet!</h4>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max1Avail"">Best {{max1Name}}: {{max1}} lbs</h4>
                </div>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max2Avail"">Best {{max2Name}}: {{max2}} lbs</h4>
                </div>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max3Avail"">Best {{max3Name}}: {{max3}} lbs</h4>
                </div>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max4Avail"">Best {{max4Name}}: {{max4}} lbs</h4>
                </div>
            </div>
        </div>

    </div>

    <a type =""b");
            WriteLiteral("utton\" class=\"btn btn-primary\" href=\"/home/progress\" id=\"progButton\"> View your progress</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
=======
#pragma checksum "D:\jmwen\repos\Capstone\Capstone\Capstone\git-ripped\Views\Home\Stats.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2daed864899c926461ecc49867825b44e0b3669b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Stats), @"mvc.1.0.view", @"/Views/Home/Stats.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Stats.cshtml", typeof(AspNetCore.Views_Home_Stats))]
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
#line 1 "D:\jmwen\repos\Capstone\Capstone\Capstone\git-ripped\Views\_ViewImports.cshtml"
using git_ripped;

#line default
#line hidden
#line 2 "D:\jmwen\repos\Capstone\Capstone\Capstone\git-ripped\Views\_ViewImports.cshtml"
using git_ripped.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2daed864899c926461ecc49867825b44e0b3669b", @"/Views/Home/Stats.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"136feb6ed5067285e18983ecff911ab0f5095069", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Stats : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/StyleSheet1.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\jmwen\repos\Capstone\Capstone\Capstone\git-ripped\Views\Home\Stats.cshtml"
  
	ViewData["Title"] = "Stats";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(82, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7aa48ac439814b80a5619d1112882779", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(136, 2150, true);
            WriteLiteral(@"

<div ng-controller=""StatsCtrl"" class=""container"" ng-cloak>

    <div ng-if=""loggedIn==false"" class=""alert alert-warning"" ng-cloak >
        <strong>Oops!</strong> Sign in to view your stats.
    </div>

    <h1 class=""text-center"">Stats</h1>
    <p class=""text-center"">
        Here you will find a summary of your current statistics.
    </p>

    <div class=""row"">
        <div class=""col-md-4"">
            <div class=""single-stat"" id=""vitals"">
                <h2 align=""center"">Git Vitals</h2>
                <center><i class=""fas fa-weight fa-5x""></i></center>
                <h4>Height:</h4>
                <h4>Weight:</h4>
                <h4>Age:</h4>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""single-stat"" id=""gitstats"">
                <h2 align=""center"">Git Stats</h2>
                <center><i class=""fas fa-pen-square fa-5x""></i></center>
                <h4>Workouts Completed:</h4>
                <h4>Goal Streak:</h4>
      ");
            WriteLiteral(@"          <h4>Record Breaks:</h4>
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""single-stat"" id=""records"">
                <h2 align=""center"">Git Records</h2>
                <center><i class=""fas fa-dumbbell fa-5x""></i></center>
                <h4 align=""center"" ng-if=""max1Avail==false"">No Bests Recorded Yet!</h4>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max1Avail"">Best {{max1Name}}: {{max1}} lbs</h4>
                </div>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max2Avail"">Best {{max2Name}}: {{max2}} lbs</h4>
                </div>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max3Avail"">Best {{max3Name}}: {{max3}} lbs</h4>
                </div>
                <div class=""text-nowrap"">
                    <h4 ng-if=""max4Avail"">Best {{max4Name}}: {{max4}} lbs</h4>
                </div>
            </div>
        </div>

    </div>

    <a type =""b");
            WriteLiteral("utton\" class=\"btn btn-primary\" href=\"/home/progress\" id=\"progButton\"> View your progress</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
>>>>>>> Stashed changes
