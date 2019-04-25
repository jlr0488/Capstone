#pragma checksum "C:\Users\Zachery.Chambers\Documents\Capstone\Capstone\git-ripped\Views\Home\Workout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd8036b0082bca61496fe20c351604aeff0b20ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Workout), @"mvc.1.0.view", @"/Views/Home/Workout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Workout.cshtml", typeof(AspNetCore.Views_Home_Workout))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd8036b0082bca61496fe20c351604aeff0b20ba", @"/Views/Home/Workout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"136feb6ed5067285e18983ecff911ab0f5095069", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Workout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Zachery.Chambers\Documents\Capstone\Capstone\git-ripped\Views\Home\Workout.cshtml"
  
	ViewData["Title"] = "Workout";
	Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(86, 1082, true);
            WriteLiteral(@"<div ng-controller=""WorkoutCtrl"" class=""container"" ng-cloak>
	<h1>Workout</h1>

	<ul class=""nav nav-tabs"" id=""workoutTabs"" role=""tablist"">
		<li ng-repeat=""lift in workout.Lifts"" class=""nav-item"">
			<a class=""nav-link"" ng-class=""{active : activeTab == lift.LiftNameID}"" ng-click=""setActiveTab(lift.LiftNameID)"" aria-selected=""{{$index==0}}"" id=""{{lift.LiftID}}"" data-toggle=""tab"" href=""#lift{{$index}}"" role=""tab"" aria-controls=""lift{{$index}}"">
				{{lift.LiftName}}
			</a>

		</li>
		<li class=""nav-item"">
			<a class=""nav-link"" ng-class=""{active : activeTab === 'addLift'}"" ng-click=""setActiveTab('addLift')"" data-toggle=""tab"" href=""#liftList"" role=""tab"" aria-controls=""liftList"">
				<i class=""fas fa-plus""></i>
			</a>
		</li>

	</ul>
	<div ng-form=""workoutForm"">
		<div class=""tab-content"" id=""myTabContent"" ng-cloak>

			<div ng-repeat=""lift in workout.Lifts"" ng-class=""{active : activeTab == lift.LiftNameID , show : activeTab == lift.LiftNameID}"" class=""mx-3 tab-pane fade"" id=""lift{{$index}}""");
            WriteLiteral(" role=\"tabpanel\" aria-labelledby=\"lift{{$index}}\">\r\n\r\n\t\t\t\t");
            EndContext();
            BeginContext(1168, 689, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "18def7896695431c9cc088a156608d09", async() => {
                BeginContext(1174, 676, true);
                WriteLiteral(@"

					<div class=""md-form row ml-1"" ng-repeat=""set in lift.SetList"">
						<div class=""col-3 px-0"">
							<input type=""number"" step=""5"" id=""weight{{lift.LiftNameID}}:{{set.SetID}}"" ng-model=""set.Weight"" class=""form-control"" required />
							<label for=""weight{{lift.LiftNameID}}:{{set.SetID}}"">Weight</label>
						</div>
						<div class=""col-1 text-center"">
							<p>&times;</p>
						</div>
						<div class=""col-3 px-0"">
							<input type=""number"" id=""reps{{lift.LiftNameID}}:{{set.SetID}}"" ng-model=""set.Repetitions"" class=""form-control"" required />
							<label for=""reps{{lift.LiftNameID}}:{{set.SetID}}"">Reps</label>
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1857, 413, true);
            WriteLiteral(@"
				<div class=""row"">
					<button class=""ml-0 btn btn-primary"" ng-click=""addSet(lift.LiftNameID)"">Add Set</button>
					<button class=""btn btn-red"" ng-click=""delSet(lift.LiftNameID)"">Delete Set</button>
				</div>


			</div>

			<div class=""mx-3 tab-pane fade"" ng-class=""{active : activeTab == 'addLift' , show : activeTab == 'addLift'}"" id=""liftList"" role=""tabpanel"" aria-labelledby=""liftList"">
				");
            EndContext();
            BeginContext(2270, 678, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aba4ae52a78a4b809dd4428ec1f17a2f", async() => {
                BeginContext(2276, 665, true);
                WriteLiteral(@"
					<div class=""md-form ml-4"">
						<input type=""text"" class=""form-control"" ng-model=""searchText"" id=""searchText"" />
						<label for=""searchText"">Search for a Workout</label>
						<ul>
							<li ng-repeat=""lift in LiftList | filter:searchText"">
								<a ng-click=""addLift(lift.LiftNameID)"">{{lift.LiftName}}</a>
							</li>

						</ul>
					</div>

					<div class=""md-form ml-4"">
						<input type=""text"" id=""newLift"" ng-model=""newLift.LiftName"" class=""form-control"" />
						<label for=""newLift"">Add New Lift Name</label>
						<button type=""submit"" class=""btn btn-green"" ng-click=""addNewLift()"">Add New Lift</button>
					</div>

				");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2948, 365, true);
            WriteLiteral(@"

			</div>


		</div>
		</div>
	
	<br />
	<button class=""btn btn-dark-green col-12 w-100"" ng-disabled=""workoutForm.$invalid || finishWorkoutProcessing || workout.Lifts.length == 0"" ng-click=""finishWorkout()""> <span class=""spinner-border spinner-border-sm"" role=""status"" aria-hidden=""true"" ng-if=""finishWorkoutProcessing""></span> Workout</button>
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
