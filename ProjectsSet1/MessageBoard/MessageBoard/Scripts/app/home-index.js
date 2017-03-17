
//home-index.js

var app = angular.module("homeIndex", ['ngRoute']);

app.config(function ($routeProvider) {
    //$locationProvider
    //    .html5Mode(false)
       
    $routeProvider.when("/", {
        controller : "topicsController",
        templateUrl : '/templates/topicsView.html'
    });
    $routeProvider.when("/newmessage", {
        controller: "newTopicController",
        templateUrl: '/templates/newTopicView.html'
    });
    $routeProvider.when("/message/:id", {
        controller: "singleTopicController",
        templateUrl:"/templates/singleTopicView.html"
    });
    $routeProvider.otherwise({ redirectTo: "/" });

});

app.factory("dataService", function ($http,$q) {

    var _topics = [];
    var _isInint = false;
    var _isReady = function () {
        return _isInint;
    }

    var _getTopics = function () {

        var deferred = $q.defer();

        $http.get("/api/v1/topics")
        .then(function (result) {
            // Successful
            angular.copy(result.data, _topics);
            _isInint = true;
            deferred.resolve();
        },
        function () {
            // Error
            deferred.reject();            
        });

        return deferred.promise;
    };

    var _addTopic = function (newTopic) {
        var deferred = $q.defer();

        $http.post("/api/v1/topics", newTopic)
            .then(function (result) {
                //sucesss
                var newlyCreatedTopic = result.data;
                _topics.splice(0, 0, newlyCreatedTopic);
                deferred.resolve(newlyCreatedTopic);
            },
            function () {
                //error
                deferred.reject();
            });

        return deferred.promise;
    };

    function _findTopic() {

    }

    var _getTopicById = function (id) {
        var deferred = $q.defer();
        if (isReady()){
            var topic = _findTopic(id);
            if (topic) {
                deferred.resolve(topic);
            } else {
                _getTopics()
                .then(function () {
                    //success
                },
                function () {
                    //error
                    deferred.reject();
                });
            }
        }
        return deferred.promise;
    };
    return {
        topics: _topics,
        getTopics: _getTopics,
        addTopic: _addTopic,
        isReady: _isReady,
        getTopicById: _getTopicById
    };

});
    
app.controller("topicsController", function($scope,$http,dataService) {
    $scope.dataCount = 0;
    $scope.data = dataService;
    $scope.isBusy = false;

    if (dataService.isReady() == false) {
        $scope.isBusy = true;
        dataService.getTopics()
            .then(function () {
                //success
            },
            function () {
                //error
                alert("Could not load topics");
            })
            .then(function () {
                $scope.isBusy = false;
            });
    }
});

app.controller("newTopicController", function ($scope, $http, $window,dataService) {
    $scope.newTopic = {};

    $scope.save = function () {
        dataService.addTopic($scope.newTopic)
        .then(function () {
            $window.location = "#/";
        },
        function () {
            //error
            alert("could not save the new Topic")
        })
    };
});

app.controller("singleTopicController", function ($scope,dataService,$window,$routeParams) {
    $scope.topic = null;
    $scope.newReply = {};

    dataService.getTopicById($routeParams.id)
    .then(function () {
        //Success
        $scope.topic = topic;
    },
    function () {
        //Error
        $window.location = "#/";

    });
    $scope.addReply = function () {

    };
});