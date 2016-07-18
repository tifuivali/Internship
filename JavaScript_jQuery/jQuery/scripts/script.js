/// <reference path="jquery-2.1.0-vsdoc.js" />



function Hotel(id, name, description, city, rooms_count, stars_count) {
    this.id = id;
    this.name = name;
    this.description = description;
    this.city = city;
    this.rooms_count = rooms_count;
    this.stars_count = stars_count;
    this.display = function () {
        console.log(name + "," + city + "," + stars_count + " stele");
    };

};


var hotel1 = new Hotel(1, "Hotel1", "aaa", "Iasi", 30, 4);
var hotel2 = new Hotel(2, "Hotel2", "bbbb", "Cluj Napoca", 100, 5);


function Hotels() {
    this.list = [];
   
}

Hotels.prototype.length = function () {
    return this.list.length;
}

Hotels.prototype.add = function (hotel) {
    var exists = false;
    for (var item in this.list) {
        if (this.list[item].id === hotel.id) {
            exists = true;
        }
    }
    if (exists) {
        throw {
            message: "Hotels with the same id:" + hotel.id + " already exists!"
        }
    }

    this.list.push(hotel);
};



Hotels.prototype.update = function (hotel) {
    var exists = false;
    for (var item in this.list) {
        if (this.list[item].id === hotel.id) {
            exists = true;
            this.list[item] = hotel;
        }
    }
    if (!exists) {
        throw {
            message: "Hotel doesn't exists!"
        }
    }
};

Hotels.prototype.delete = function (id) {
    var exists = false;
    for (var item in this.list) {
        if (this.list[item].id === id) {
            exists = true;
            this.list.splice(item, 1);
        }
    }
    if (!exists) {
        throw {
            message: "Hotel doesn't exists!"
        }
    }
};


Hotels.prototype.getInfo = function (id) {
    for (var item in this.list) {
        if (this.list[item].id === id) {
            return this.list[item].name + "-" + this.list[item].city + "-" + this.list[item].stars_count + " stele";
        }
    }
}


Hotels.prototype.getAllInfo = function () {
    var infos = [];
    for (var item in this.list) {
        infos.push(this.getInfo(this.list[item].id));
    }
    return infos;
};

Hotels.prototype.get = function (index){
    return this.list[index];
}





$(document).ready(function () {

    // Exercise1();
    exercise2();
    exercise3();


});


function exercise1()
{
    console.log($('#hotelsContainer').html());
    $('#third span').each(function () {
        console.log($(this).html());
    });
    $('.right').each(function () {
        console.log($(this).html());
    });

    $('h1').css('color', 'red');
    $('span').css('color', 'blue');

}


//exercise2

function HotelsTableGenerator(args) {
    this.args = args;
}

HotelsTableGenerator.prototype.generateTable = function () {
    var container = this.args.container.append('<table><thead><th>ID</th><th>Name</th><th>Description</th><th>City</th><th>Rooms Count</th><th>Rating</th><th>Operations</th></thead></table>');
    var tableHotels = $(container).find('table');
    var tbody=tableHotels.append('<tbody></tbody>').find('tbody');
    for (var i = 0 ; i < this.args.hotels.length() ; i++) {
        tbody.append(createRow(this.args.hotels.get(i)));
    }
};

function createRow(hotel) {
    var row = '';
    row += '<tr data-id=' + hotel.id + '>';
    var cell = '';
    cell += '<td>' + hotel.id + '</td>';
    cell += '<td>' + hotel.name + '</td>';
    cell += '<td>' + hotel.description + '</td>';
    cell += '<td>' + hotel.city + '</td>';
    cell += '<td>' + hotel.rooms_count + '</td>';
    cell += '<td>' + hotel.stars_count + '</td>';
    cell += '<td></td>';
    row += cell;
    return row;
}





function exercise2() {
    generate2HotelsTest();
}

function generate2HotelsTest() {
    var args = {
        hotels: new Hotels(),
        container: $('#hotelsContainer')
    };
    args.hotels.add(hotel1);
    args.hotels.add(hotel2);
    var hotelTableGenerator = new HotelsTableGenerator(args);
    hotelTableGenerator.generateTable();
}

function exercise3() {
   
   
    var container = $('#hotelsContainer').append('<input id=\'addButton\' type=\'button\' value=\'Add\'/>');
    var buttonAdd = $(container).on('click', '#addButton', function () {
        var tbody = $(container).find('tbody').prepend(createInputsRow(6));
        $(tbody).find('#btnConfirm').click(function () {
            var inputs = $(tbody).find('tr input[data-id]');
            inputs.each(function () {

            })
        });
        $(this).prop('disabled', true);
    });
}

function createInputsRow(numberOfCell) {
    var row = '<tr>';
    row += '<td><input data-id=\'id\' type=\'text\'/></td>';
    row += '<td><input data-id=\'name\' type=\'text\'/></td>';
    row += '<td><input data-id=\'description\' type=\'text\'/></td>';
    row += '<td><input data-id=\'city\' type=\'text\'/></td>';
    row += '<td><input data-id=\'rooms_count\' type=\'text\'/></td>';
    row += '<td><input data-id=\'stars_count\' type=\'text\'/></td>';
    var divOp = createDivOperations();
    row += '<td>' + divOp;
    row += '</td>';
    row += '</tr>';
    return row;
}

function createDivOperations(){
    var div = '<div>';
    div += '<input type=\'button\' value=\'Confirm\' id=\'btnConfirm\'/>';
    div += '<input type=\'button\' value=\'Cancel\' id=\'btnCancel\'/>';
    div += '</div>'
    return div;
}