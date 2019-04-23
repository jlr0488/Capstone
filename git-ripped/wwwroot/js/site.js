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

    $scope.attributes = {
        height: "",
        startingWeight: "",
        currentWeight: "",
        goalWeight: "",
        gender: "",
        birthday: "",
        waistMeasure: "",
        armMeasure: "",
        chestMeasure: "",
        backMeasure: "",
        legMeasure: "",
        
    }

    $scope.submitAttributesForm = function () {

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

    $scope.mailSetting = {
        oldEmail: "",
        newEmail: "",
        password: ""
    };

    $scope.submitMailSettingForm = function () {
        //send validation info plus new password info that will need hashing
    }
	
});

app.controller('WorkoutCtrl', function ($scope, $http, $window) {
	//will eventually turn into, $scope.workout = getWorkout http stuff
	var startDateTime = new Date().toJSON("yyyy/MM/dd HH:mm");
	$scope.newLift = {
		SessionToken: 1,
		LiftName: ""
		
		//turn into get token, that we will get at the beggining
	};

	$scope.workout = {
		SessionToken: 1,
			NumberLifts: 0,
			WorkoutComplete: "N",
			StartDateTime: startDateTime,
						CompleteDateTime: "",
							Lifts: []		
	};


	$scope.getLiftList = function () {
		$http.get("../../api/GetLiftList")
			.then(function (response) {
				$scope.LiftList = response.data;
				console.log($scope.LiftList);
			})
			, function (response) {
				alert("An error has occured getting Lift List" + response.data);
			}
	}

	$scope.init = function () {
		$scope.finishWorkoutProcessing = false;
		$scope.getLiftList();
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
		$scope.activeTab = 'addLift';

		
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
				$scope.addSet(liftID);
				var indexToRemove = $scope.LiftList.indexOf(element);
				$scope.LiftList.splice(indexToRemove, 1);
			}
		})
		console.log($scope.workout);
		$scope.activeTab = liftID;
		console.log($scope.activeTab);

	}

	$scope.addNewLift = function () {
		$http.post("../../api/CreateLift", JSON.stringify($scope.newLift))
			.then(function (response) {
				$scope.newLift.name = "";
				$scope.getLiftList();
			}
			, function (response) {
				alert("Creating new lift was unsuccessful, Please try again.")
			})
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

	$scope.setActiveTab = function (LiftNameID) {
		if (!isNaN(LiftNameID)) {
			$scope.activeTab = LiftNameID;
		}
		else {
			$scope.activeTab = "addLift";
		}
		
	}

	$scope.finishWorkout = function () {
		$scope.finishWorkoutProcessing = true;
		var completeDateTime = new Date().toJSON("yyyy/MM/dd HH:mm");
		$scope.workout.CompleteDateTime = completeDateTime;
		console.log(JSON.stringify($scope.workout));
		$http.post("../../api/CreateWorkout", JSON.stringify($scope.workout))
			.then(function () {
				$scope.finishWorkoutProcessing = false;

				alert("Your workout has been saved, you can see it when you View Past Workouts!");
				$window.location.href = "/home";
			}, function (error) {
				$scope.finishWorkoutProcessing = false;

				$scope.error = error.data;
				$scope.errorWords = $scope.error.split(" ");
				if ($scope.errorWords[0] == "Index") {
					alert("Please choose at least one workout")
				}
				else {
					alert("Please enter a repetition and weight amount.")
				}
				//alert($scope.error);
				//alert("Your workout failed to save. Please try again.");
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

app.controller('StatsCtrl', function ($scope, $http, $location) {

    //git records card connected to back end
    $scope.initRecords = function () {
        $http.get("../api/LiftRecords?tok=1")
            .then(function (response) {
                $scope.recordList = response.data;
                console.log($scope.recordList);
                $scope.benchMax = $scope.recordList[0].Max;
                console.log($scope.benchMax);
                $scope.mPressMax = $scope.recordList[1].Max;
                console.log($scope.mPressMax);
                $scope.inclinePressMax = $scope.recordList[2].Max;
                console.log($scope.inclinePressMax);
                $scope.squatMax = $scope.recordList[3].Max;
                console.log($scope.squatMax);

            })
            , function (response) {
                alert("An error has occured getting Lift Records");
            }
    }();

})

app.controller('ProgressCtrl', function ($scope, $http, $location) {
    //filling graph with dummy data in order to show in demo
    var myChart = document.getElementById('myChart').getContext('2d');
    var benchChart = new Chart(myChart, {
        type: 'line',
        data: {
            labels: ['January', 'February', 'March', 'April'],
            datasets: [{
                label: 'Bench Press',
                data: [
                    0,
                    95,
                    105,
                    165,
                ],
                borderColor: 'rgb(102, 178, 255)',
                backgroundColor: 'rgb(102,178,255)',
                fill: false,
                lineTension: 0,


            },
               {
                   label: 'Military Press',
                   data: [
                       20,
                       45,
                       85,
                       95,
                       135,
                   
                   ],
                   borderColor: 'rgb(0, 204, 102)',
                   backgroundColor: 'rgb(0,204,12)',
                   fill: false,
                   lineTension: 0,

                },
                {
                    label: 'Incline Press',
                    data: [
                        45,
                        65,
                        95,
                        115,
                        135,
                        165,

                    ],
                    borderColor: 'rgb(255,178,102)',
                    backgroundColor: 'rgb(255,178,102)',
                    fill: false,
                    lineTension: 0,

                },

                {
                    label: 'Squat',
                    data: [
                        45, 
                        95,
                        135,
                        185,
                        225,

                    ],
                    borderColor: 'rgb(204,153,255)',
                    backgroundColor: 'rgb(204,153,255)',
                    fill: false,
                    lineTension: 0,

                }]
        },
        options: {}
    });



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

        //this is for getting variables in correct order for api
        $scope.basicInfoStr = {
            //add username to register UI
            //username: $scope.basicInfo.username,
            UserName: "brayberg",
            Mail: $scope.basicInfo.email,
            FirstName: $scope.basicInfo.firstName,
            LastName: $scope.basicInfo.lastName,
            Password: $scope.basicInfo.password
        };
        console.log(JSON.stringify($scope.basicInfoStr));
        $http.post("../../api/CreateUser", JSON.stringify($scope.basicInfoStr))
            .then(function () {
                $scope.loggedIn = true;
                alert("Your account has been created.");
                $window.location.href = "/home";
                //need to add in token response and save to token var

            }, function (error) {

            }
        )
	}


	$scope.doesPasswordMatch = function () {
		return ($scope.basicInfo.password === $scope.basicInfo.password2 && $scope.basicInfo.password !== "" && $scope.basicInfo.password2 !== "");
	}
});
