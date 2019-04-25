// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var app = angular.module("gitRipped", ['ngCookies']);

app.controller('indexCtrl', function ($scope, $http) {
	//do stuff for index Page
	$scope.pounds = 0;
	brickWeight = 7.71618;
	carWeight = 4009;
	eighteenWheelerWeight = 80000;
	planeWeight = 735000;





	$scope.getTotalWeight = function () {
		$http.get("../../api/totalWeightByWeek?tok=" + $scope.SessionToken)
			.then(function (results) {
				$scope.recordsList = results.data;
				$scope.recordsList.forEach(function (element) {
					$scope.pounds += element.TotalWeight;
					
				})
				$scope.getItemAmount();
			}, function () {
				alert("GET Lift Records failed")
			})
	};
	

	$scope.init = function () {
		if ($scope.loggedIn == true) {
			$scope.getTotalWeight();
		}
		else {

		}
	}();



	$scope.getItemAmount = function () {

		
		console.log("$scope.pounds = " + $scope.pounds);
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
	};
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
        //populate the attributes 
        $scope.attributesStr = {
            SessionToken: $scope.SessionToken,
            Height: $scope.attributes.height,
            StartingWeight: $scope.attributes.startingWeight,
            CurrentWeight: $scope.attributes.currentWeight,
            GoalWeight: $scope.attributes.goalWeight,
            Gender: $scope.attributes.gender,
            Birthday: $scope.attributes.birthday,
            WaistMeasure: $scope.attributes.waistMeasure,
            ArmMeasure: $scope.attributes.armMeasure,
            ChestMeasure: $scope.attributes.chestMeasure,
            BackMeasure: $scope.attributes.backMeasure,
            LegMeasure: $scope.attributes.legMeasure
        };
        console.log($scope.attributesStr);
        $http.post("../../api/CreateUserAttributes", JSON.stringify($scope.attributesStr))
            .then(function (response) {
                alert("Your attributes have beeen saved.");
            })
            , function (response) {
                //error 
            } 
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
        SessionToken: $scope.SessionToken,
		LiftName: ""
		
		//turn into get token, that we will get at the beggining
	};

	$scope.workout = {
		SessionToken: $scope.SessionToken,
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
				$scope.OrigionalLiftList = response.data;
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
			$http.get("../../api/Workout?tok=" + $scope.SessionToken + "&workID=" + $scope.workoutID)
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

	function titleCase(str) {
		str = str.toLowerCase().split(' ');
		for (var i = 0; i < str.length; i++) {
			str[i] = str[i].charAt(0).toUpperCase() + str[i].slice(1);
		}
		return str.join(' ');
	}

	$scope.addNewLift = function () {
		var isInLiftList = false;
		$scope.newLift.LiftName = titleCase($scope.newLift.LiftName);
		$scope.OrigionalLiftList.forEach(function (element) {
			if (element.LiftName == $scope.newLift.LiftName) {
				isInLiftList = true;
			}
		})
		if (!isInLiftList && $scope.newLift.LiftName != "") {
			$http.post("../../api/CreateLift", JSON.stringify($scope.newLift))
				.then(function (response) {
					$scope.newLift.LiftName = "";
					$scope.getLiftList();
				}
					, function (response) {
						alert("Creating new lift was unsuccessful, Please try again.")
					})
		}
		
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
        $scope.workout.WorkoutComplete = "Y";
		console.log(JSON.stringify($scope.workout));
		$http.post("../../api/CreateWorkout", JSON.stringify($scope.workout))
			.then(function () {
				$scope.finishWorkoutProcessing = false;

				alert("Your workout has been saved, you can see it when you View Past Workouts!");
				$window.location.href = "/home/findworkout";
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
        $http.get("../api/getWorkoutList?tok=" + $scope.SessionToken)
			.then(function (response) {
				$scope.workoutList = response.data;
                var test = 2;
			})
			, function (response) {
				alert("An error has occured getting workoutList");
			}

		


	}();
})

app.controller('StatsCtrl', function ($scope, $http, $location) {

    //git records card connected to back end
    $scope.initRecords = function () {
        if ($scope.loggedIn) {
            $http.get("../api/LiftRecords?tok=" + $scope.SessionToken)
                .then(function (response) {
                    $scope.recordList = response.data;
                    console.log($scope.recordList);
                    try {
                        $scope.max1 = $scope.recordList[0].Max;
                        $scope.max1Name = $scope.recordList[0].LiftName;
                        $scope.max1Avail = true;
                    }
                    catch{
                        $scope.max1Avail = false;
                    }
                    try {
                        $scope.max2 = $scope.recordList[1].Max;
                        $scope.max2Name = $scope.recordList[1].LiftName;
                        $scope.max2Avail = true;
                    }
                    catch{
                        $scope.Max2Avail = false;
                    }
                    try {
                        $scope.max3 = $scope.recordList[2].Max;
                        $scope.max3Name = $scope.recordList[2].LiftName;
                        $scope.max3Avail = true;
                    }
                    catch
                    {
                        $scope.max3Avail = false;
                    }
                    try {
                        $scope.max4 = $scope.recordList[3].Max;
                        $scope.max4Name = $scope.recordList[3].LiftName;
                        $scope.max4Avail = true;
                    }
                    catch{
                        $scope.Max4Avail = false;
                    }


                })
                , function (error) {
                    alert("An error has occured getting Lift Records");
                }
        }
        else {
            $scope.max1Avail = false;
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

app.controller('LayoutCtrl', function ($scope, $http, $cookies, $location, $window) {
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

        if (typeof ($cookies.get("GRsessionToken")) === 'undefined') {
			$scope.loggedIn = false;
			if ($window.location.pathname != "/home" && $window.location.pathname != "/") {
				$window.location.href = "/home";
			}
        }
        else {
            $scope.loggedIn = true;
            $scope.SessionToken = $cookies.get("GRsessionToken");
        }
    }();


	$scope.signIn = function(){
		//need to salt the password
		//send http post or something to the server using basicInfo.username and basicInfo.password
        $scope.loginInfo = {
            Username: $scope.basicInfo.username,
            Password: $scope.basicInfo.password
        };
        $http.post("../../api/GetLogin", JSON.stringify($scope.loginInfo))
            .then(function (response) {
                $scope.loggedIn = true;
                console.log(response.data);
                $cookies.put("GRsessionToken", response.data);
                //$cookies.GRsessionUsername = $scope.basicInfo.username;
				$('#SigninModal').modal('hide');
				$window.location.href = "/"
            } , function (error) {
                alert("Username and Password Combination Incorrect.")
            })
        var test = 2 + 3;
    }

    $scope.signOut = function () {
        $cookies.remove("GRsessionToken");
        $window.location.href = "/home";
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
        //$scope.basicInfo.username = $scope.basicInfo.email.split('@')[0];
        //this is for getting variables in correct order for api
        $scope.basicInfoStr = {
            //username: $scope.basicInfo.username,
			UserName: $scope.basicInfo.email.split("@")[0],
            Email: $scope.basicInfo.email,
            FirstName: $scope.basicInfo.firstName,
            LastName: $scope.basicInfo.lastName,
            Password: $scope.basicInfo.password
        };
        console.log(JSON.stringify($scope.basicInfoStr));
        $http.post("../../api/CreateUser", JSON.stringify($scope.basicInfoStr))
            .then(function () {
                alert("Your account has been created.");
                //$window.location.href = "/home"; doesn't like this
                $scope.signIn();
            }, function (error) {

            }
        )
	}


	$scope.doesPasswordMatch = function () {
		return ($scope.basicInfo.password === $scope.basicInfo.password2 && $scope.basicInfo.password !== "" && $scope.basicInfo.password2 !== "");
	}
});
