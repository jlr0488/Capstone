#pragma checksum "C:\Users\Zachery.Chambers\Documents\Capstone\Capstone\git-ripped\Views\Home\Stats.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "723559d3115147a89d4f9544d3de6904e22b6a56"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"723559d3115147a89d4f9544d3de6904e22b6a56", @"/Views/Home/Stats.cshtml")]
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ded0de24e7d342ce85ce2f429bfcd212", async() => {
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
            BeginContext(136, 1686, true);
            WriteLiteral(@"

<div ng-controller=""StatsCtrl"" class=""container"" ng-cloak>

    <div class=""alert alert-warning"">
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
                <h4>Record Breaks:</h4>");
            WriteLiteral(@"
            </div>
        </div>
        <div class=""col-md-4"">
            <div class=""single-stat"" id=""records"">
                <h2 align=""center"">Git Records</h2>
                <center><i class=""fas fa-dumbbell fa-5x""></i></center>
                <h4>Best Bench: {{benchMax}} lbs</h4>
                <h4>Best Military Press: {{mPressMax}} lbs</h4>
                <h4>Best Incline Press: {{inclinePressMax}} lbs</h4>
                <h4>Best Squat: {{squatMax}}</h4>



            </div>
        </div>

    </div>

    <a type =""button"" class=""btn btn-primary"" href=""/home/progress"" id=""progButton""> View your progress</a>
</div>
");
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
