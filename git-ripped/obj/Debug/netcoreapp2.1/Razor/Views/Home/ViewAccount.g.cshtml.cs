#pragma checksum "D:\jmwen\repos\Capstone\Capstone\git-ripped\Views\Home\ViewAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "032cc3d0e81f434066b648c4562004fdf76dfeef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewAccount), @"mvc.1.0.view", @"/Views/Home/ViewAccount.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewAccount.cshtml", typeof(AspNetCore.Views_Home_ViewAccount))]
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
#line 1 "D:\jmwen\repos\Capstone\Capstone\git-ripped\Views\_ViewImports.cshtml"
using git_ripped;

#line default
#line hidden
#line 2 "D:\jmwen\repos\Capstone\Capstone\git-ripped\Views\_ViewImports.cshtml"
using git_ripped.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"032cc3d0e81f434066b648c4562004fdf76dfeef", @"/Views/Home/ViewAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"136feb6ed5067285e18983ecff911ab0f5095069", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Profile Photo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Car.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle img-responsive"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("120"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("120"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("BasicInfoForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-center border border-light p-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\jmwen\repos\Capstone\Capstone\git-ripped\Views\Home\ViewAccount.cshtml"
  
    ViewData["Title"] = "ViewAccount";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(96, 987, true);
            WriteLiteral(@"
<div class=""container"" ng-controller=""ViewAccountCtrl"">
	<ul class=""nav nav-tabs md-tabs"" id=""ViewAccountTabs"" role=""tablist"">
		<li class=""nav-item"">
			<a class=""nav-link active"" id=""BasicInfo"" data-toggle=""tab"" href=""#basicInfo"" role=""tab"" aria-controls=""basicInfo""
			   aria-selected=""true"">Basic Info</a>
		</li>
		<li class=""nav-item"">
			<a class=""nav-link"" id=""MailSettings"" data-toggle=""tab"" href=""#mailSettings"" role=""tab"" aria-controls=""mailSettings""
			   aria-selected=""false"">Mail Settings</a>
		</li>
		<li class=""nav-item"">
			<a class=""nav-link"" id=""ChangePassword"" data-toggle=""tab"" href=""#changePass"" role=""tab"" aria-controls=""changePass""
			   aria-selected=""false"">Change Password</a>
		</li>
	</ul>
	<div class=""tab-content card pt-5"" id=""ViewAccountTabsContent"">
		<div class=""tab-pane fade show active"" id=""basicInfo"" role=""tabpanel"" aria-labelledby=""BasicInfo"">
			<div class=""row"">
				<div class=""text-center col-12 account-avatar"">
					");
            EndContext();
            BeginContext(1083, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "70bee9df8ae44d009281dfae174feb88", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1192, 63, true);
            WriteLiteral("\r\n\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<!-- Default form register -->\r\n\t\t\t");
            EndContext();
            BeginContext(1255, 1316, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b2bfb597ad6b4de792ab652244653bdd", async() => {
                BeginContext(1324, 1240, true);
                WriteLiteral(@"

				<div class=""form-row mb-4"">
					<div class=""col"">
						<!-- First name -->
						<input type=""text"" id=""FirstName"" ng-model=""firstName"" class=""form-control"" placeholder=""First name"">
					</div>
					<div class=""col"">
						<!-- Last name -->
						<input type=""text"" id=""LastName"" ng-model=""lastName"" class=""form-control"" placeholder=""Last name"">
					</div>
				</div>
				<div class=""form-row"">
					<!-- E-mail -->
					<input type=""email"" id=""Email"" ng-model=""email"" class=""form-control mb-4"" placeholder=""E-mail"">
				</div>

				<div class=""form-row mb-4"">
					<!--Username-->
					<input type=""text"" id=""Username"" ng-model=""username"" class=""form-control"" placeholder=""Username"">
				</div>

				<div class=""form-row mb-4"">
					<!-- Password -->
					<input type=""password"" id=""Password"" ng-model=""password"" class=""form-control"" placeholder=""Password"" aria-describedby=""dPasswordHelpBlock"">
					<small id=""PasswordHelpBlock"" class=""form-text text-muted mb-4"">
						At least 8 cha");
                WriteLiteral("racters and 1 digit\r\n\t\t\t\t\t</small>\r\n\t\t\t\t</div>\r\n\r\n\r\n\r\n\t\t\t\t<!-- Sign up button -->\r\n\t\t\t\t<button class=\"btn btn-info my-4 btn-block\" ng-click=\"submitBasicInfoForm()\" type=\"submit\">Update Profile</button>\r\n\r\n\r\n\r\n\r\n\r\n\t\t\t");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2571, 376, true);
            WriteLiteral(@"
			<!-- Default form register -->
		</div>
		<div class=""tab-pane fade"" id=""mailSettings"" role=""tabpanel"" aria-labelledby=""MailSettings"">
			
		</div>
		<div class=""tab-pane fade"" id=""changePass"" role=""tabpanel"" aria-labelledby=""ChangePassword"">
            		<div class=""row"">
                		<div class=""text-center col-12 account-avatar"">
                    		");
            EndContext();
            BeginContext(2947, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1908d0f543e049c28cbcc19019bf7319", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3056, 88, true);
            WriteLiteral("\r\n                \t\t</div>\r\n            \t\t</div>\r\n\t\t\t<!-- Default form register -->\r\n\t\t\t");
            EndContext();
            BeginContext(3144, 2455, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f613f850bae04a66a47088bef817b6dc", async() => {
                BeginContext(3213, 2379, true);
                WriteLiteral(@"

				<div class=""form-row"">
					<!-- E-mail -->
					<input type=""email"" id=""ChangePassEmail"" ng-model=""changePass.email"" class=""form-control mb-4"" placeholder=""E-mail"" required=""required"" />
				</div>

               		 	<div class=""form-row mb-4"">
                    			<!--Username-->
                    			<input type=""text"" id=""ChangePassUsername"" ng-model=""changePass.username"" class=""form-control"" placeholder=""Username"" required=""required""/>
                		</div>

                		<div class=""form-row mb-4"">
                    			<!-- Old Password -->
                    			<input type=""password"" id=""ChangePassOldPassword"" ng-model=""changePass.oldPassword"" class=""form-control"" placeholder=""Old Password"" aria-describedby=""dPasswordHelpBlock"" required=""required""/>
                		</div>

                		<div class=""form-row mb-4"">
                    			<!-- New Password -->
                    			<input type=""password"" id=""ChangePassNewPassword"" ng-model=""changePass.newPass");
                WriteLiteral(@"word"" class=""form-control"" placeholder=""New Password"" aria-describedby=""dPasswordHelpBlock"" required=""required""/>
                    			<small id=""PasswordHelpBlock"" class=""form-text text-muted mb-4"">
                        		At least 8 characters and 1 digit
                    			</small>
               				</div>

                		<div class=""form-row mb-4"">
                    			<!-- New Password Confirmation-->
                    			<input type=""password"" id=""ChangePassNewPassword2"" ng-blur=""doesPasswordMatch()"" ng-model=""changePass.newPassword2"" class=""form-control"" placeholder=""Confirm New Password"" aria-describedby=""dPasswordHelpBlock"" required=""required""/>
                    			<div class=""alert alert-warning"" ng-if=""!doesPasswordMatch() && changePass.NewPassword.$dirty && changePass.NewPassorwd2.$dirty"">Passwords are not correct or don't match </div>
                    			<small id=""PasswordHelpBlock"" class=""form-text text-muted mb-4"">
                        		At least 8 character");
                WriteLiteral(@"s and 1 digit
                    			</small>
                		</div>

                		<!-- sign up button -->
                		<button class=""btn btn-info my-4 btn-block"" ng-click=""submitChangePassForm()"" ng-disabled=""changePass.$invalid || !doesPasswordMatch()"" type=""submit"">Change Password</button>


            		");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5599, 84, true);
            WriteLiteral("\r\n            \t\t<!-- Default form register -->\r\n\t\t</div>\r\n\t</div>\r\n\r\n\r\n\t\r\n</div>\r\n\r\n");
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
