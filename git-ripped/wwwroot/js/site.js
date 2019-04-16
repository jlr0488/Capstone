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

app.controller('WorkoutCtrl', function ($scope, $http, $window) {
	//will eventually turn into, $scope.workout = getWorkout http stuff
	var startDateTime = new Date().toJSON("yyyy/MM/dd HH:mm");
	$scope.workout = {
		SessionToken: 1,
			NumberLifts: 0,
			WorkoutComplete: "N",
			StartDateTime: startDateTime,
						CompleteDateTime: "",
							Lifts: []		
	};
	$scope.init = function () {
		$http.get("../../api/GetLiftList")
			.then(function(response){
				$scope.LiftList = response.data;
				console.log($scope.LiftList);
			})
			, function (response) {
				alert("An error has occured getting Lift List" + response.data);
			}
		$scope.workoutID = window.location.pathname.split('/').pop();
		console.log($scope.workoutID);
		if (!isNaN($scope.workoutID)) {
			$http.get("../../api/Workout?tok=1&workID=" + $scope.workoutID)
				.then(function (response) {
					$scope.workout = angular.fromJson(response.data);
					console.log($scope.workout);
				})
				, function (response) {
					alert("An error has occured getting workout 1");
				}
		}
		

		
	}();
	
	$scope.addLift = function (liftID) {
		$scope.LiftList.forEach(function (element) {
			if (element.LiftNameID === liftID) {
				console.log(element);
				var newLift = {
					Sets: 0,
					LiftOrderNumber: $scope.workout.NumberLifts + 1,
					LiftNameID: element.LiftNameID,
					LiftName: element.LiftName,
					SetList: []
				}
				$scope.workout.Lifts.push(newLift);
				$scope.workout.NumberLifts++;
			}
		})
		console.log($scope.workout);
	}


	$scope.addSet = function (liftID) {
		$scope.workout.Lifts.forEach(function (element) {
			if (element.LiftNameID === liftID) {
				element.Sets = Number(element.Sets) + 1;
				var newSet = {
					Repetitions: "",
					Weight: "",
					SetOrderNumber: element.LiftOrderNumber + 1
				}
				element.SetList.push(newSet);
				
			}
		})
	}

	$scope.delSet = function (liftID) {
		$scope.workout.Lifts.forEach(function (element) {
			if (element.LiftNameID === liftID) {
				element.Sets = Number(element.Sets) - 1;
				element.SetList.pop();
			}
		})
	}

	$scope.finishWorkout = function () {
		var completeDateTime = new Date().toJSON("yyyy/MM/dd HH:mm");
		$scope.workout.CompleteDateTime = completeDateTime;
		console.log(JSON.stringify($scope.workout));
		$http.post("../../api/CreateWorkout", JSON.stringify($scope.workout))
			.then(function () {
				alert("Your workout has been saved, you can see it when you View Past Workouts!");
				$window.location.href = "/home";
			}, function () {
				alert("Your workout failed to save. Please try again.");
			}
			)

	}


})

app.controller('FindWorkoutCtrl', function ($scope, $http) {
	$scope.init = function () {
		$scope.workoutList = [{}];
		$http.get("../api/getWorkoutList?tok=1")
			.then(function (response) {
				$scope.workoutList = response.data;

			})
			, function (response) {
				alert("An error has occured getting workoutList");
			}

		


	}();
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
