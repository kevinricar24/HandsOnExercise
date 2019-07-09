var app = angular.module("employeeModule", []);
var urlPath = "https://localhost:44302/employee/";

app.controller("employeeController", function ($scope, $http) {

    $scope.GetAllData = function () {
        var Id = document.getElementById("idEmployee").value;
        $http({
            method: "get",
            url: urlPath + "GetEmployeeById/" + Id
        }).then(function (response) {
            $scope.employees = response.data;
        });
    };

    $scope.DeleteEmployee = function (Id) {
        $http({
            method: "post",
            url: urlPath + "DeleteEmployee/" + Id
        }).then(function (response) {
            $scope.GetAllData();
        });
    };

});  