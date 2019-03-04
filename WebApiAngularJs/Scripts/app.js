/// <reference path="angular.js" />
var host = 'http://localhost:63006/';
var app = angular.module("myApp", []);

app.controller("ProductCtrl", function ($scope, $http) {
    $scope.productList = [];

    function init() {
        $http({
            method: "GET",
            url: host + "/api/product/getall"
        }).then(function (rs) {
            console.log(rs);
            if (rs.data.success) {
                $scope.productList = rs.data.data;
            } else {
                alert("bir hata oluştu " + rs.data.message);
            }
        }
    

    $scope.getall = function () {
       
    }
    init();
});