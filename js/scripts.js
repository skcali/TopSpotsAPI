angular.module('SanDiegoTopSpots', []);

angular
	.module('SanDiegoTopSpots')
	.controller('printTable', printTable);

function printTable($http) {

  var vm = this;

  $http.get('http://localhost:62993/api/topspots').then(function (response) {
    vm.places = response.data;
  });

  vm.locationLink = function locationLink(lat, lon) {
    window.open("https://www.google.com/maps/preview/@" + lat + "," + lon + ",18z");
  };


};
