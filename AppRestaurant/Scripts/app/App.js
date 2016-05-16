//create angularjs controller
var app = angular.module('app', []);//set and get the angular module
app.controller('clientController', ['$scope', '$http', clientController]);

//angularjs controller method
function clientController($scope, $http) {
    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all client information
    $http.get('/api/Clientes/').success(function (data) {
        $scope.clientes = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.clientes.editMode = !this.clientes.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Inser client
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Clientes/', this.newcustomer).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.clientes.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Customer! " + data;
            $scope.loading = false;
        });
    };

    //Edit Client
    $scope.save = function () {
        alert("Editar");
        $scope.loading = true;
        var frien = this.clientes;
        alert(frien);
        $http.put('/api/Clientes/' + frien.IdCliente, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving customer! " + data;
            $scope.loading = false;
        });
    };

    //Delete Customer
    $scope.deletecustomer = function () {
        $scope.loading = true;
        var Id = this.clientes.IdCliente;
        $http.delete('/api/Clientes/' + Id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.clientes, function (i) {
                if ($scope.clientes[i].Id === Id) {
                    $scope.clientes.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Customer! " + data;
            $scope.loading = false;
        });
    };

}
///----------------------------------------------------------------------------MESA
app.controller('mesaController', ['$scope', '$http', mesaController]);

//angularjs controller method
function mesaController($scope, $http) {
    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all client information
    $http.get('/api/Mesas/').success(function (data) {
        $scope.mesa = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.mesa.editMode = !this.mesa.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Inser client
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Mesas/', this.newcustomer).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.mesa.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Customer! " + data;
            $scope.loading = false;
        });
    };

    //Edit Client
    $scope.save = function () {
        alert("Editar");
        $scope.loading = true;
        var frien = this.mesa;
        alert(frien);
        $http.put('/api/Mesas/' + frien.IdMesa, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving customer! " + data;
            $scope.loading = false;
        });
    };

    //Delete Customer
    $scope.deletecustomer = function () {
        $scope.loading = true;
        var Id = this.mesa.IdMesa;
        $http.delete('/api/Mesas/' + Id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.mesa, function (i) {
                if ($scope.mesa[i].Id === Id) {
                    $scope.mesa.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Customer! " + data;
            $scope.loading = false;
        });
    };

}


///----------------------------------------------------------------------------CAMARERO
app.controller('camareroController', ['$scope', '$http', camareroController]);

//angularjs controller method
function camareroController($scope, $http) {
    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all client information
    $http.get('/api/Camareros/').success(function (data) {
        $scope.camarero = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.camarero.editMode = !this.camarero.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Inser client
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Camareros/', this.newcustomer).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.camarero.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Customer! " + data;
            $scope.loading = false;
        });
    };

    //Edit Client
    $scope.save = function () {
        alert("Editar");
        $scope.loading = true;
        var frien = this.camarero;
        alert(frien);
        $http.put('/api/Camareros/' + frien.IdCamarero, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving customer! " + data;
            $scope.loading = false;
        });
    };

    //Delete Customer
    $scope.deletecustomer = function () {
        $scope.loading = true;
        var Id = this.camarero.IdCamarero;
        $http.delete('/api/Camareros/' + Id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.camarero, function (i) {
                if ($scope.camarero[i].Id === Id) {
                    $scope.camarero.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Customer! " + data;
            $scope.loading = false;
        });
    };

}
///----------------------------------------------------------------------------COCINERO
app.controller('cocineroController', ['$scope', '$http', cocineroController]);

//angularjs controller method
function cocineroController($scope, $http) {
    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all client information
    $http.get('/api/Cocineros/').success(function (data) {
        $scope.cocinero = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.cocinero.editMode = !this.cocinero.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Inser client
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Cocineros/', this.newcustomer).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.cocinero.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Customer! " + data;
            $scope.loading = false;
        });
    };

    //Edit Client
    $scope.save = function () {
        alert("Editar");
        $scope.loading = true;
        var frien = this.cocinero;
        alert(frien);
        $http.put('/api/Cocineros/' + frien.IdCocinero, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving customer! " + data;
            $scope.loading = false;
        });
    };

    //Delete Customer
    $scope.deletecustomer = function () {
        $scope.loading = true;
        var Id = this.cocinero.IdCocinero;
        $http.delete('/api/Cocineros/' + Id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.cocinero, function (i) {
                if ($scope.cocinero[i].Id === Id) {
                    $scope.cocinero.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Customer! " + data;
            $scope.loading = false;
        });
    };

}

///----------------------------------------------------------------------------FACTURA
app.controller('facturaController', ['$scope', '$http', facturaController]);

//angularjs controller method
function facturaController($scope, $http) {
    //declare variable for mainain ajax load and entry or edit mode
    $scope.loading = true;
    $scope.addMode = false;

    //get all client information
    $http.get('/api/Facturas/').success(function (data) {
        $scope.factura = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error = "An Error has occured while loading posts!";
        $scope.loading = false;
    });

    //by pressing toggleEdit button ng-click in html, this method will be hit
    $scope.toggleEdit = function () {
        this.factura.editMode = !this.factura.editMode;
    };

    //by pressing toggleAdd button ng-click in html, this method will be hit
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Inser client
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Facturas/', this.newcustomer).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.factura.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Customer! " + data;
            $scope.loading = false;
        });
    };

    //Edit Client
    $scope.save = function () {
        alert("Editar");
        $scope.loading = true;
        var frien = this.factura;
        alert(frien);
        $http.put('/api/Facturas/' + frien.IdFactura, frien).success(function (data) {
            alert("Saved Successfully!!");
            frien.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving customer! " + data;
            $scope.loading = false;
        });
    };

    //Delete Customer
    $scope.deletecustomer = function () {
        $scope.loading = true;
        var Id = this.factura.IdFactura;
        $http.delete('/api/Facturas/' + Id).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.factura, function (i) {
                if ($scope.factura[i].Id === Id) {
                    $scope.factura.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Customer! " + data;
            $scope.loading = false;
        });
    };

}


