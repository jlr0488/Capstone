// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var app = angular.module("gitRipped", []);

app.controller('indexCtrl', function ($scope, $http) {
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

app.controller('ViewAccountCtrl', function ($scope, $http) {
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

	$scope.changePass = {
		email: "",
		username: "",
		oldPassword: "",
		newPassword: "",
		newPassword2: ""
	};

	$scope.submitChangePassForm = function () {
		//send validation info plus new password info that will need hashing 
	}

	$scope.doesPasswordMatch = function () {
		return ($scope.changePass.newPassword === $scope.changePass.newPassword2 && $scope.changePass.newPassword !== "" && $scope.changePass.newPassword2 !== "");
	} 

	
});

app.controller('WorkoutCtrl', function ($scope, $http) {
	//will eventually turn into, $scope.workout = getWorkout http stuff
	$scope.workout = {
		SessionToken: 1,
		NumberLifts: 3,
		WorkoutComplete: "Y",
		StartDateTime: "",
		CompleteDateTime: "",
		Lifts: [
			{
				Sets: 3,
				LiftOrderNumber: 1,
				LiftNameID: 1,
				LiftName: "Bench Press",
				SetList: [
					{
						Repetitions: 4,
						Weight: 50,
						SetOrderNumber: 1
					},
					{
						Repetitions: 4,
						Weight: 50,
						SetOrderNumber: 2
					},
					{
						Repetitions: 4,
						Weight: 50,
						SetOrderNumber: 3
					}
				]
			},
			{
				Sets: 2,
				LiftOrderNumber: 2,
				LiftNameID: 4,
				LiftName: "Incline Press",
				SetList: [
					{
						Repetitions: 4,
						Weight: 50,
						SetOrderNumber: 1
					},
					{
						Repetitions: 4,
						Weight: 50,
						SetOrderNumber: 2
					}
				]
			},
			{
				Sets: 1,
				LiftOrderNumber: 3,
				LiftNameID: 2,
				LiftName: "Overhead Press",
				SetList: [
					{
						Repetitions: 4,
						Weight: 50,
						SetOrderNumber: 1
					}
				]
			}
		]
	};
	$scope.init = function () {
		$http.get("../api/Workout/1/2/")
			.then(function (response) {
				$scope.workout = angular.fromJson(response.data);

			})
			, function (response) {
				alert("An error has occured getting workout 1");
			}

		console.log($scope.workout);
	}();
	
	


	$scope.addSet = function (liftID) {
		$scope.workout.Lifts.forEach(function (element) {
			if (element.LiftID === liftID) {
				element.Sets = Number(element.Sets) + 1;
				var newSet = {
					setID: element.Sets,
					LiftID: liftID,
					reps: "",
					weight: "",
					setOrderNum: element.LiftOrderNumber + 1
				}
				element.SetList.push(newSet);
				
			}
		})
	}

	$scope.delSet = function (liftID) {
		$scope.workout.Lifts.forEach(function (element) {
			if (element.LiftID === liftID) {
				element.Sets = Number(element.Sets) - 1;
				element.SetList.pop();
			}
		})
	}


})

app.controller('LayoutCtrl', function ($scope, $http) {
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
	

	$scope.loggedIn = true;

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
