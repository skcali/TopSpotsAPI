angular.module('SanDiegoTopSpots', []);

angular
    .module('SanDiegoTopSpots')
    .controller('printTable', printTable);

function printTable($http) {
    var vm = this;
		// Grabbing the JSON file
    $http.get('http://localhost:62993/api/topspots').then(function(response) {
        vm.places = response.data;
    });
		// Click function to add a new place to Top Spots
    vm.addPlace = function() {
        var dataObj = {
            name: vm.name,
            description: vm.description,
            locatoin: null
        };
        $http.post('http://localhost:62993/api/topspots', dataObj).then(function(response) {
            vm.places.push(dataObj);
        })
    }
		// Click function to delete the last place in the table
    vm.deleteLastPlace = function(place) {
        var dataObj = {
            name: vm.name,
            description: vm.description,
            locatoin: null
        };
        $http.delete('http://localhost:62993/api/topspots', place).then(function(response) {
            vm.places.pop(dataObj);
        })
    }
		// Click function to delete the place in the row the button is in
    vm.deletePlace = function(place) {
        $http.delete('http://localhost:62993/api/topspots', place).then(function(response) {
            vm.places.splice(vm.places.indexOf(place), 1);
        })
    }
		// Click function to open up Google maps based on the latitude and longitude given
    vm.locationLink = function locationLink(lat, lon) {
        window.open("https://www.google.com/maps/preview/@" + lat + "," + lon + ",18z");
    };


};
