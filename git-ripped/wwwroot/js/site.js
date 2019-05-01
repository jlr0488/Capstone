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

app.controller('ViewAccountCtrl', function ($scope, $http, $cookies, $window, $filter) {
    $scope.init = function () {
        $http.get("../api/GetAttributes?tok=" + $scope.SessionToken)
            .then(function (response) {
                $scope.attributes.height = response.data.Height;
                $scope.attributes.currentWeight = response.data.CurrentWeight;
                $scope.attributes.startingWeight = response.data.StartingWeight;
                $scope.attributes.goalWeight = response.data.GoalWeight;
                $scope.attributes.gender = response.data.Gender;
                $scope.attributes.birthday = $filter('date')(response.data.Birthday, 'MM/dd/yyyy', 'CST');
                $scope.attributes.waistMeasure = response.data.WaistMeasure;
                $scope.attributes.armMeasure = response.data.ArmMeasure;
                $scope.attributes.chestMeasure = response.data.ChestMeasure;
                $scope.attributes.backMeasure = response.data.BackMeasure;
                $scope.attributes.legMeasure = response.data.LegMeasure;
            })
        $http.get("../api/GetUser?tok=" + $scope.SessionToken)
            .then(function (response) {
                $scope.basicInfo.firstName = response.data.FirstName;
                $scope.basicInfo.lastName = response.data.LastName;
                $scope.basicInfo.email = response.data.Email;
                $scope.basicInfo.username = response.data.UserName;
            })
    }();

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

	$scope.basicInfo = {
		firstName : "",
		lastName : "",
		email : "",
		username : "",
		password: "",
		password2: ""
	};
    
    //this populates the user info in view account
    $http.get("../../api/GetUser?tok=" + $scope.SessionToken)
        .then(function (response) {
            $scope.basicInfo.firstName = response.data.FirstName;
            $scope.basicInfo.lastName = response.data.LastName;
            $scope.basicInfo.email = response.data.Email;
            $scope.basicInfo.username = response.data.UserName;

        })
        , function (response) {
            alert("Cannot get user data.")
        }

    console.log($scope.basicInfo);
	$scope.submitBasicInfoForm = function () {
		//validate and send info through a post (after hashing password)


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
            Birthday: $filter('date')($scope.attributes.birthday,'MM/dd/yyyy','CST'),
            WaistMeasure: $scope.attributes.waistMeasure,
            ArmMeasure: $scope.attributes.armMeasure,
            ChestMeasure: $scope.attributes.chestMeasure,
            BackMeasure: $scope.attributes.backMeasure,
            LegMeasure: $scope.attributes.legMeasure
        };
        console.log($scope.attributesStr);
        $http.post("../../api/CreateAttributes", JSON.stringify($scope.attributesStr))
            .then(function (response) {
                alert("Your attributes have beeen saved.");
            })
            , function (response) {
                //error 
            } 
    }

	$scope.changePass = {
		username: "",
		password: "",
		newPassword: "",
	};

	$scope.submitChangePassForm = function () {
		//send validation info plus new password info that will need hashing
        console.log($scope.changePass.username);
        $http.post("../../api/ChangePassword", JSON.stringify($scope.changePass))
            .then(function (response) {
                alert("Your password has been changed.\nYou must sign back in with your new password.");
                try {
                    $cookies.remove("GRsessionToken", { path: '/' });                
                    $window.location.href = "/home";
                }
                catch (error) {
                    console.log(error);
                }
            }
            , function (response) {
                alert("Password Change Error!")
            })
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
				$scope.activeTab = $scope.LiftList[0].LiftNameID;
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
			})
			, function (response) {
				alert("An error has occured getting workoutList");
			}

		


	}();
})

app.controller('StatsCtrl', function ($scope, $http, $location, $filter) {

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
            $http.get("../api/GetNumberWorkouts?tok=" + $scope.SessionToken)
                .then(function (response) {
                    $scope.NumberWorkouts = response.data.NumberWorkouts;
                })
            $http.get("../api/GetAttributes?tok=" + $scope.SessionToken)
                .then(function (response) {
                    $scope.CurrentWeight = response.data.CurrentWeight;
                    height = response.data.Height;
                    feet = Math.floor(height / 12);
                    inches = height % 12;
                    $scope.Height = feet + "\' " + inches + "\"";
                    birthday = response.data.Birthday;
                    birthYear = parseInt($filter('date')(birthday, 'yyyy', 'CST').toString());
                    var d = new Date();
                    currentYear = parseInt(d.getFullYear());
                    $scope.Age = currentYear - birthYear;
                })
        }
        else {
            $scope.max1Avail = false;
        }
    }();

})

app.controller('ProgressCtrl', function ($scope, $http, $location) {
    $scope.eList = [];
    $scope.wList = [];
    $scope.eListWithDuplicates = [];
    $scope.initRecords = function () {
        if ($scope.loggedIn) {
            $http.get("../api/TotalWeightByWeekByLift?tok=" + $scope.SessionToken)
                .then(function (response) {
                    $scope.progressList = response.data;
                    console.log($scope.progressList);

                   
                    
                    //putting exercises and weeks in different lists to use later
                    for (var i = 1; i < $scope.progressList.length + 1; i++) {
                        $scope.eList[i] = $scope.progressList[i - 1].LiftName;
                        $scope.wList[i] = $scope.progressList[i - 1].WeekStart;
                        $scope.eListWithDuplicates[i-1] = $scope.progressList[i-1].LiftName;

                    }
                    
                    $scope.eList[1] = 0;
                    $scope.wList[0] = '';

                    //removing duplicates from exercises
                    $scope.exerciseList = $scope.eList.filter(function (elem, index, self) {
                        return index == self.indexOf(elem);
                    })

                    //removing duplicates from weeks
                    $scope.WeekStartList = $scope.wList.filter(function (elem, index, self) {
                        return index == self.indexOf(elem);
                    })

                    //colors that each exercise will get
                    var colors = [
                        'rgba(102,178,255)',
                        'rgba(0, 204, 102)',
                        'rgba(255, 178, 102)',
                        'rgba(204, 153, 255)',
                        'rgba(255, 51, 5)',
                        'rgba(0, 204, 204)'

                        /*'rgba(102,178,255)',
                        'rgba(0, 204, 102)',
                        'rgba(255, 178, 102)',
                        'rgba(204, 153, 255)',
                        'rgba(255, 51, 5)',
                        'rgba(0, 204, 204)'
                        'rgba(102,178,255)',
                        'rgba(0, 204, 102)',
                        'rgba(255, 178, 102)',
                        'rgba(204, 153, 255)',
                        'rgba(255, 51, 5)',
                        'rgba(0, 204, 204)'
                        'rgba(102,178,255)',
                        'rgba(0, 204, 102)',
                        'rgba(255, 178, 102)',
                        'rgba(204, 153, 255)',
                        'rgba(255, 51, 5)',
                        'rgba(0, 204, 204)'
                        'rgba(102,178,255)',
                        'rgba(0, 204, 102)',
                        'rgba(255, 178, 102)',
                        'rgba(204, 153, 255)',
                        'rgba(255, 51, 5)',
                        'rgba(0, 204, 204)'
                        */

                    ]

                   
                     $scope.nExercise = [];

                    //algorithm to get lists of each lift without duplicates and total weight 
                    for (var i = 0; i < $scope.exerciseList.length; i++) {
                        $scope.nExercise[i] = $scope.exerciseList[i];
                    }
                    
                    for (var i = 1; i < $scope.progressList.length+1; i++) {
                       
                        for (var j = 0; j < $scope.nExercise.length; j++) {
                            if ($scope.progressList[i - 1].LiftName == $scope.nExercise[j]) {

                                $scope.exerciseList[i] = [];
                                $scope.exerciseList[i].splice(i - 1, 0, $scope.nExercise[i]);
                                $scope.exerciseList[j].splice(i + 1, 0, $scope.progressList[i - 1].TotalWeight);
                            }
                        }
                    }



                    /*
                    console.log($scope.exerciseList[1][0]);
                    console.log($scope.exerciseList[1][1]);
                    console.log($scope.exerciseList[1][2]);
                    console.log($scope.exerciseList[1][3]);
                    

                    console.log("break");
                    */

                    for (var i = 1; i < $scope.exerciseList.length; i++) {
                        $scope.exerciseList[i].splice(1, 0, 0);
                    }

                    $scope.exerciseList[1].splice(4, 0, 300);
                    $scope.exerciseList[2].splice(2, 0, 320);
                    $scope.exerciseList[2].splice(3, 0, 640);
                    $scope.exerciseList[3].splice(2, 0, 240);
                    $scope.exerciseList[4].splice(2, 0, 525);

                    var total = 506;
                    for (var i = 2; i < 6; i++) {
                        $scope.exerciseList[5].splice(i, 0, total)
                        total = total + 506;
                    }

               
                  
                    //dynamically adding lines/number of lifts and their dates to chart
                    var myChart = document.getElementById('myChart').getContext('2d');
                    var benchChart = new Chart(myChart, {
                        type: 'line',
                        data: {
                            labels: $scope.WeekStartList,
                            datasets: []
                        },
                        options: {
                            plugins: { datalabels: {display:false}},
                            scales: {
                                yAxes: [{ scaleLabel: { display: true,labelString:'Total Weight',fontSize:18,padding:32|top}}],
                                xAxes: [{
                                    scaleLabel: {
                                        display: true,
                                        labelString: 'Week Of',
                                        fontSize: 18,
                                        padding:32|top
                                    }
                                }]
                            }
                        }

                    });

                  
                    //pushing data to graph
                    for (var i = 1; i < $scope.nExercise.length; i++) {
                        var newDataset = {
                            label: $scope.exerciseList[i][0],
                            data: [],
                            lineTension: 0,
                            fill: false,
                            showline: true,
                            borderColor: colors[i],
                            backgroundColor: colors[i]
                        };

                        for (j = 1; j < 9; j++) {
                           
                            newDataset.data.push($scope.exerciseList[i][j]);
                        }

                        benchChart.config.data.datasets.push(newDataset);
                    }

                    benchChart.update();
                    
                 
                })
                , function (error) {
                    alert("An error has occured getting Lift Records");
                }
        }
    }();

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
                $cookies.put("GRsessionToken", response.data, { path: '/' });
                //$cookies.GRsessionUsername = $scope.basicInfo.username;
				$('#SigninModal').modal('hide');
				$window.location.href = "/"
            } , function (error) {
                alert("Username and Password Combination Incorrect.")
            })
        var test = 2 + 3;
    }

	$scope.signOut = function () {
		$http.get("../../api/logout?tok=" + $scope.SessionToken)
			.then(function (response) {
				alert("you have logged out.");
				$cookies.remove("GRsessionToken", { path: '/' });

				$window.location.href = "/home";
			}, function (response) {
				alert("logout failed, Please try again.")
			})
	
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
			UserName: $scope.basicInfo.username,
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
