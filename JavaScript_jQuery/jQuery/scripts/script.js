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


Hotels.prototype.getHotelById = function (id) {
    var exists = false;
    for (var item in this.list) {
        if (this.list[item].id === id) {
            exists = true;
            return this.list[item];
        }
    }
    if (!exists) {
        throw {
            message: "Hotel doesn't exists!"
        }
    }
}


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
    var hotel1 = new Hotel(1, "Hotel1", "aaa", "Iasi", 30, 4);
    var hotel2 = new Hotel(2, "Hotel2", "bbbb", "Cluj Napoca", 100, 5);
    var hotel3 = new Hotel(3, "Hotel3", "cccc", "Bucuresti", 40, 4);
    var hotel4 = new Hotel(4, "Hotel4", "dddd", "Constanta", 150, 5);
    var hotel5 = new Hotel(5, "Hotel5", "fff", "Pitesti", 20, 1);
    args.hotels.add(hotel1);
    args.hotels.add(hotel2);
    console.log(args);

    
    /*
       Exercices
    */
    // Exercise1();
    exercise2(args);
    exercise3(args);
    exercise4(args);
    exercise5(args);
    args.url = 'scripts/hotels.json';
    exercise6(args);
    exercise7(args);
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
    $(container).append('<input id=\'addButton\' type=\'button\' value=\'Add\'/>')
                .append('<input id=\'btnLoad\' type=\'button\' value=\'Load\'/>');
};

function createRow(hotel) {
    var row = '';
    row += '<tr data-id=\'' + hotel.id + '\'>';
    var cell = '';
    cell += '<td>' + hotel.id + '</td>';
    cell += '<td>' + hotel.name + '</td>';
    cell += '<td>' + hotel.description + '</td>';
    cell += '<td>' + hotel.city + '</td>';
    cell += '<td>' + hotel.rooms_count + '</td>';
    cell += '<td>' + hotel.stars_count + '</td>';
    cell += '<td><input type=\'button\' class=\'btnDelete\' value=\'Delete\'/> <input type=\'button\' class=\'btnEdit\' value=\'Edit\'/></td>';
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


//exercise 3
function exercise3(args) {
   
   
    var container = args.container;
    var btnAdd = $(container).find('#addButton');
    $(container).on('click', '#addButton', function () {
        var tbody = $(container).find('tbody').prepend(createInputsRow());
        $(tbody).find('#btnConfirm').click(function () {
            var hotel = getHotelFromRow($(this).closest('tr'));
            try{
                args.hotels.add(hotel);
                $(tbody).append(createRow(hotel));
                $(tbody).find('tr:first-child').remove();
                btnAdd.prop('disabled', false);
            } catch (e) {
                alert(e.message);
            } 
        });
        $(this).prop('disabled', true);
    });
    $(container).on('click', '#btnCancel', function () {
        $(this).closest('tr').remove();
        btnAdd.prop('disabled', false);
    });

}

function getHotelFromRow(context){
    var hotel = new Hotel();
    hotel.id = parseInt($('input[data-id=id]', context ).val());
    hotel.name = $('input[data-id=name]', context).val();
    hotel.description = $('input[data-id=description]', context).val();
    hotel.city = $('input[data-id=city]', context).val();
    hotel.rooms_count = $('input[data-id=rooms_count]', context).val();
    hotel.stars_count = $('input[data-id=stars_count]', context).val();
    return hotel;
}


// exercise 4
function exercise4(args){
        args.container.on('click', '.btnDelete', function () {
        var currentRow = $(this).closest('tr');
        var hotelID = parseInt(currentRow.attr('data-id'));
        var response = confirm("Do you want to delete this hotel?");
        if (response === true) {
            args.hotels.delete(hotelID);
            currentRow.remove();
        }
        
    });
}



function createInputsRow() {
    var row = '<tr>';
    row += '<td><input data-id=\'id\' type=\'number\'/></td>';
    row += '<td><input data-id=\'name\' type=\'text\'/></td>';
    row += '<td><input data-id=\'description\' type=\'text\'/></td>';
    row += '<td><input data-id=\'city\' type=\'text\'/></td>';
    row += '<td><input data-id=\'rooms_count\' type=\'number\'/></td>';
    row += '<td><input data-id=\'stars_count\' type=\'number\'/></td>';
    var divOp = createDivOperations();
    row += '<td>' + divOp;
    row += '</td>';
    row += '</tr>';
    return row;
}

function createEditRow(hotel) {
    var row = '<tr>';
    row += '<td><input data-id=\'id\' value=\'' + hotel.id+ '\' type=\'number\' readonly /></td>';
    row += '<td><input data-id=\'name\' value=\'' + hotel.name +'\' type=\'text\'/></td>';
    row += '<td><input data-id=\'description\' value=\'' + hotel.description + '\' type=\'text\'/></td>';
    row += '<td><input data-id=\'city\' value=\'' + hotel.city + '\' type=\'text\'/></td>';
    row += '<td><input data-id=\'rooms_count\' value=\'' + hotel.rooms_count + '\' type=\'number\'/></td>';
    row += '<td><input data-id=\'stars_count\' value=\'' + hotel.stars_count + '\' type=\'number\'/></td>';
    var divOp = createDivOperations();
    row += '<td>' + divOp;
    row += '</td>';
    row += '</tr>';
    return row;
}

//exercise5
function exercise5(args) {
    args.container.on('click', '.btnEdit', function () {
        var restoreRow = $(this).closest('tr').html();
        var tr = $(this).closest('tr');
        var hotelToEdit = args.hotels.getHotelById(parseInt(tr.attr('data-id')));
        tr = tr.replaceWith(createEditRow(hotelToEdit));
        var tbody = args.container.find('tbody');
        tbody.on('click', '#btnConfirm', function () {
            var currentRow = $(this).closest('tr');
            var editedHotel = getHotelFromRow(currentRow);
            args.hotels.update(editedHotel);
            currentRow.replaceWith(createRow(editedHotel));
        });
        tbody.on('click','#btnCancel',function (){
            var tr = $(this).closest('tr');
            tr.replaceWith(restoreRow);
        });
    });

}


//exercise 6
function exercise6(args,url) {
    var container = args.container;
    $(container).on('click', '#btnLoad', function () {
        $(container).children().remove();
        $.ajax({
            url: args.url,
            dataType: 'json',
            success: function (data, status, xhr) {
                var hotels = new Hotels();
                hotels.list = data.list;
                var argss = {
                    hotels: hotels,
                    container: $('#hotelsContainer')
                };
                var tableGenerator = new HotelsTableGenerator(argss);
                tableGenerator.generateTable();
                args.hotels.list = argss.hotels.list;
            },
            error: function (xhr, status, error) {
                alert("Fail load hotels! \n"+error);
            }
        });
    }); 
}


//exercise 7
function exercise7(args){
    var inputSearch = $('#searchInput');
    var btnClear = $('#btnClear');
    btnClear.click(function () {
        args.container.find('tr[data-id]').css('display', '');
    });
    inputSearch.on('input',function (e) {
        var nameHotel = inputSearch.val();
        filterByName(nameHotel, args);
    });
    var searchContainer = $('.SearchContainer');
    searchContainer.on('click', '#btnSearch', function () {
        
    });
}

function filterByName(name,args){
    var container = args.container;
    container.find('tr[data-id]').each(function () {
        var hotelName = $(this).find('td:eq(1)').text();
        if(hotelName.toLowerCase().includes(name.toLowerCase())) {
            $(this).css('display', '');
        }
        else {
            $(this).css('display', 'none');
        }
        
    });
}

function createDivOperations(){
    var div = '<div>';
    div += '<input type=\'button\' value=\'Confirm\' id=\'btnConfirm\'/>';
    div += '<input type=\'button\' value=\'Cancel\' id=\'btnCancel\'/>';
    div += '</div>'
    return div;
}
