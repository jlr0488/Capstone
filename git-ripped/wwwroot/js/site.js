// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var app = angular.module("gitRipped", []);

app.controller('indexCtrl', function ($scope) {
	//do stuff for index Page
	$scope.pounds = 125000;
	brickWeight = 7.71618;
	carWeight = 4009;
	eighteenWheelerWeight = 80000;
	planeWeight = 735000

	$scope.getItemAmount = function () {
		if ($scope.pounds <= carWeight) {
			if ($scope.pounds / brickWeight == 1) {
				$scope.item = "Brick";
			} else {
				$scope.item = "Bricks";
			}
			$scope.numItems = $scope.pounds / brickWeight;
			$scope.imagePath = "images/Brick.jpg";
		}
		else if ($scope.pounds <= eighteenWheelerWeight) {
			if ($scope.pounds / carWeight == 1) {
				$scope.item = "Car";
			}
			else {
				$scope.item = "Cars";
			}

			$scope.numItems = $scope.pounds / carWeight;
			$scope.imagePath = "images/Car.svg";
		}
		else if ($scope.pounds <= planeWeight) {
			if ($scope.pounds / eighteenWheelerWeight == 1) {
				$scope.item = "Eighteen Wheeler";
			}
			else {
				$scope.item = "Eighteen Wheelers";
			}
			$scope.numItems = $scope.pounds / eighteenWheelerWeight;
			$scope.imagePath = "images/18Wheeler.png";
		}
		else if ($scope.pounds > planeWeight) {
			$scope.item = "Planes";
			$scope.numItems = $scope.pounds / planeWeight;
			$scope.imagePath = "images/plane.png";
		}
		else {
			console.log("There is an error with the weight");
		}

		$scope.numItems = $scope.numItems.toFixed(2);
	}();
});

app.controller('ViewAccountCtrl', function ($scope) {
	$scope.basicInfo = {
		firstName : "",
		lastName : "",
		email : "",
		username : "",
		password: "",
		password2: ""
	};

	$scope.submitBasicInfoForm = function () {
		//validate and send info through a post (after hashing password)

	}

	
});

app.controller('LayoutCtrl', function ($scope) {
	$(".nav .nav-link").on("click", function () {
		$("li.active").removeClass("active");
		$('a[href="' + location.pathname + '"]').closest('li').addClass('active');
	}());
	$scope.init = function () {
		$scope.basicInfo = {
			firstName: "",
			lastName: "",
			email: "",
			username: "",
			password: "",
			password2: ""
		};
	}();
	

	$scope.loggedIn = false;

	$scope.signIn = function(){
		//need to salt the password
		//send http post or something to the server useing basicInfo.pass and basicInfo.email
		
	}

	$scope.clearBasicUserInfo = function () {
		$scope.basicInfo = {
			firstName: "",
			lastName: "",
			email: "",
			username: "",
			password: "",
			password2: ""
		};
	}

	$scope.register = function()	{
		//need to salt pass
		//send http post or something to the server using basicInfo, make sure the order is right with zac
	}


	$scope.doesPasswordMatch = function () {
		return ($scope.basicInfo.password === $scope.basicInfo.password2 && $scope.basicInfo.password !== "" && $scope.basicInfo.password2 !== "");
	}
});