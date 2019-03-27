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

	
});

app.controller('WorkoutCtrl', function ($scope, $http) {
	//will eventually turn into, $scope.workout = getWorkout http stuff

	$scope.workout = {
		id: "1",
		userID: "1",
		numberLifts: "2",
		workoutComplete: "N",
		StartDateTime: "",
		CompleteDateTime: "",
		Lifts: [
			{
				LiftID: "1",
				WorkoutID: "1",
				Sets: "3",
				LiftOrderNumber: "1",
				LiftNameID: "1",
				LiftName: "Bench Press",
				setList: [
					{
						setID: "1",
						LiftID: "1",
						reps: "",
						weight: "",
						setOrderNum: "1"
					},
					{
						setID: "2",
						LiftID: "1",
						reps: "",
						weight: "",
						setOrderNum: "2"
					},
					{
						setID: "3",
						LiftID: "1",
						reps: "",
						weight: "",
						setOrderNum: "3"
					}
				]
			},
			{
				LiftID: "2",
				WorkoutID: "1",
				Sets: "3",
				LiftOrderNumber: "2",
				LiftNameID: "2",
				LiftName: "Incline Press",
				setList: [
					{
						setID: "1",
						LiftID: "2",
						reps: "",
						weight: "",
						setOrderNum: "1"
					},
					{
						setID: "2",
						LiftID: "2",
						reps: "",
						weight: "",
						setOrderNum: "2"
					},
					{
						setID: "3",
						LiftID: "2",
						reps: "",
						weight: "",
						setOrderNum: "3"
					}
				]
			}

		]
	};

	$scope.addSet = function (liftID) {
		$scope.workout.Lifts.forEach(function (element) {
			if (element.LiftID === liftID) {
				element.Sets = String(Number(element.Sets) + 1);
				var newSet = {
					setID: element.Sets,
					LiftID: "2",
					reps: "",
					weight: "",
					setOrderNum: "3"
				}
				element.setList.push(newSet);
				
			}
		})
	}

	$scope.delSet = function (liftID) {
		$scope.workout.Lifts.forEach(function (element) {
			if (element.LiftID === liftID) {
				element.Sets = String(Number(element.Sets) - 1);
				element.setList.pop();
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
