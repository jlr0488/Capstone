#pragma checksum "D:\jmwen\repos\Capstone\Capstone\Capstone\git-ripped\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2e6df2b9272f599529b79511e40a7810a55649dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2e6df2b9272f599529b79511e40a7810a55649dc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"136feb6ed5067285e18983ecff911ab0f5095069", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\jmwen\repos\Capstone\Capstone\Capstone\git-ripped\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 1086, true);
            WriteLiteral(@"<div ng-controller=""indexCtrl"" ng-cloak>
	<div ng-if=""loggedIn"">
		<div class=""text-center mt-5"">
			<a href=""/home/workout""><button class=""btn btn-primary btn-block mb-5"">Start Your Workout!</button></a>
		</div>

		<div class=""text-center"" ng-cloak>
			<h4>You've Lifted {{pounds}} LBS! That's Equivilent to {{numItems}} {{item}}</h4>
			<img class=""img-circle img-fluid"" src=""{{imagePath}}"" height=""500"" width=""500"" />
		</div>
	</div>
	<div ng-if=""!loggedIn"" class=""container"">
		<div class=""mt-5"">
			<h5>This is Git -Ripped a site where you can log your workouts. This site was made by 5 college students:</h5>
			<ul>
				<li>Jon Wendt</li>
				<li>Zac Chambers</li>
				<li>Juan Orta</li>
				<li>Josh Robbins</li>
				<li>&</li>
				<li>Brayden Burglund</li>
			</ul>
			<p>To use this workout logger, Please <a style=""color:blue"" data-toggle=""modal"" data-target=""#RegisterModal"">Register</a> for an account or <a style=""color:blue"" data-toggle=""modal"" data-target=""#SigninModal"">Log in</a> if");
            WriteLiteral(" you already have an account.</p>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n");
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
