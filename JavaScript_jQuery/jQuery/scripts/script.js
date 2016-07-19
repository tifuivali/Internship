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


    var args = {
        hotels: new Hotels(),
        container: $('#hotelsContainer')
    };
    args.hotels.add(hotel1);
    args.hotels.add(hotel2);
    // Exercise1();
    exercise2(args);
    exercise3(args);
    exercise4(args);


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
    cell += '<td><input type=\'button\' class=\'btnDelete\' value=\'Delete\'/></td>';
    row += cell;
    return row;
}





function exercise2(args) {
    generate2HotelsTest(args);
}

function generate2HotelsTest(args) {

    var hotelTableGenerator = new HotelsTableGenerator(args);
    hotelTableGenerator.generateTable();
}

function exercise3(args) {
   
   
    var container = args.container.append('<input id=\'addButton\' type=\'button\' value=\'Add\'/>');
    var btnAdd = $(container).find('#addButton');
    $(container).on('click', '#addButton', function () {
        var tbody = $(container).find('tbody').prepend(createInputsRow(6));
        $(tbody).find('#btnConfirm').click(function () {
            var hotel = new Hotel();
            var tr = $(this).closest('tr');
            hotel.id = $('input[data-id=id]', tr).val();
            hotel.name = $('input[data-id=name]', tr).val();
            hotel.description = $('input[data-id=description]', tr).val();
            hotel.city = $('input[data-id=city]', tr).val();
            hotel.rooms_count = $('input[data-id=rooms_count]', tr).val();
            hotel.stars_count = $('input[data-id=stars_count]', tr).val();
            args.hotels.add(hotel);
            $(tbody).append(createRow(hotel));
            $(tbody).find('tr:first-child').remove();
            btnAdd.prop('disabled', false);
        });
        $(this).prop('disabled', true);
    });
    $(container).on('click', '#btnCancel', function () {
        $(tbody).find('tr:first-child').remove();
        btnAdd.prop('disabled', false);
    });

}

function exercise4(args){
    args.container.on('click', '.btnDelete', function () {
        var currentRow = $(this).closest('tr');
        var hotelID = currentRow.attr('data-id');
        args.hotels.delete(hotelID);
        currentRow.remove();
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