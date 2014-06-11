var app = angular.module("MyApp", []).
  config(function($routeProvider, $locationProvider) {
    $locationProvider.hashPrefix('!');
    $routeProvider.
      when("/persons", { templateUrl: "partials/index.html" }).
      when("/persons/:id", { templateUrl: "partials/show.html", controller: "ShowCtrl" }).
      when("/login", { templateUrl: "partials/login.html", controller: "LoginCtrl" }).
      when("/help", { templateUrl: "partials/help.html" }).
      otherwise( { redirectTo: "/persons" });
  }).
  run(function($rootScope, $location) {

    $rootScope.$on( "$routeChangeStart", function(event, next, current) {
      if ($rootScope.loggedInUser == null) {
        // no logged user, redirect to /login
        if ( next.templateUrl === "partials/login.html") {
        } else {
          $location.path("/login");
        }
      }
    });
  });

app.factory("Person", function() {

  var persons = [
    { name: "Peter", age: 25, id: 1 },
    { name: "Stefan", age: 35, id: 2 },
    { name: "Agnes", age: 22, id: 3 }
  ];

  return {
    all: function() {
      return persons;
    },
    get: function(id) {
      var result = null;
      angular.forEach(persons, function(p) {
        if (p.id == id) result = p;
      });
      return result;
    }
  };
});

app.controller("IndexCtrl", function($scope, Person) {
  $scope.persons = Person.all();
});

app.controller("ShowCtrl", function($scope, $routeParams, Person) {
  $scope.person = Person.get($routeParams.id);
});

app.controller("MainCtrl", function($scope, $location) {
  $scope.menuClass = function(page) {
    var current = $location.path().substring(1);
    return page === current ? "active" : "";
  };
});

app.controller("LoginCtrl", function($scope, $location, $rootScope) {
  $scope.login = function() {
    $rootScope.loggedInUser = $scope.username;
    $location.path("/persons");
  };
});