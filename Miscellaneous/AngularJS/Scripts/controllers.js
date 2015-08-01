var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope) {
    $scope.firstName = "John";
    $scope.lastName = "Doe";
})

var personAppl = angular.module('personApp', []);
personAppl.controller('personCtrl', function ($scope) {
    $scope.firstName = "John C";
    $scope.lastName = "Doe";

    $scope.fullName = function () {
        return $scope.firstName + " " + $scope.lastName;
    }
})

var personAppObjects = angular.module('personAppObjects', []);
personAppObjects.controller('personCtrlObjects', function ($scope) {
    $scope.persons = [
        { name: 'Marcia', phone: 123456 },
        { name: 'Bishnu', phone: 10543234 },
        { name: 'Amol', phone: 2424234 }
    ];
});

var customerAppObject = angular.module('customersApp', []);
customerAppObject.controller('customersController', function ($scope, $http) {
    var requestUrl = 'http://www.w3schools.com/angular/customers.php';
    $http.get(requestUrl)
    .success(function (response) {
        $scope.customers = response.records;
    });
});



