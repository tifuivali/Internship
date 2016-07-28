/// <reference path="jquery-2.1.0-vsdoc.js" />

(function () {
    "use strict";
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

    Hotels.prototype.get = function (index) {
        return this.list[index];
    }

    ///column must be the name of column
    Hotels.prototype.filter = function (key, column) {
        var filtredElements = [];
        for (var i = 0 ; i < this.list.length; i++) {
            if (this.list[i][column].toUpperCase().includes(key.toUpperCase().trim())) {
                filtredElements.push(this.list[i]);
            }
        }
        return filtredElements;
    }




    $(document).ready(function () {

        /*
        var hotel1 = new Hotel(1, "Hotel1", "aaa", "Iasi", 30, 4);
        var hotel2 = new Hotel(2, "Hotel2", "bbbb", "Cluj Napoca", 100, 5);
        var hotel3 = new Hotel(3, "Hotel3", "cccc", "Bucuresti", 40, 4);
        var hotel4 = new Hotel(4, "Hotel4", "dddd", "Constanta", 150, 5);
        var hotel5 = new Hotel(5, "Hotel5", "fff", "Pitesti", 20, 1);
        */


        var args = {
            hotels: new Hotels(),
            container: $('#list_hotels'),
            url: 'http://localhost:50581/api/Hotels',
            page: 1,
        };

        addFilterPage(args);
        //activate search
        exercise7(args);
        addNumberOfPageBehavior(args);
        var generator = new HotelsTableGenerator(args);
        generator.generateTable();;
    });


    function addFilterPage(args) {
         $('.filterContent-expanded').hide();
        $('.filterContent-expanded button[value=x]')
            .click(function() {
                $('.filterContent-expanded').hide();
            });
        $('.filterContent input')
            .click(function () {
                $('.filterContent-expanded').show();
            });
        $('section')
            .click(function () {
                $('.filterContent-expanded').hide();
            });

        $('.filterContent-expanded input[name=filter]')
            .click(function() {
                //filter elements
                var expandedContainer = $(this).closest('.filterContent-expanded');
                var city = expandedContainer.find('select').val();
                var minRoomsCount = parseInt(expandedContainer.find('input[name=minRoomsCount]').val());
                var maxRoomsCount = parseInt(expandedContainer.find('input[name=maxRoomsCount]').val());
                var minRating = parseInt(expandedContainer.find('input[name=minRating]').val());
                var maxRating = parseInt(expandedContainer.find('input[name=maxRating]').val());
                var nameToSearch = $('#search').val();
                args.city = city;
                args.itemsPerPage = parseInt($('.numberOfPage select').val());
                args.page = 1;
                args.nameToSearch = nameToSearch;
                args.minRating = minRating;
                args.maxRating = maxRating;
                args.minRoomsCount = minRoomsCount;
                args.maxRoomsCount = maxRoomsCount;
                var generator = new HotelsTableGenerator(args);
                generator.generateTable();
            });
    }

    function addNumberOfPageBehavior(args) {
        $('.numberOfPage select').change(
                function () {
                    var itemsPerPage = parseInt($(this).val());
                    args.itemsPerPage = itemsPerPage;
                    var gen = new HotelsTableGenerator(args);
                    gen.generateTable();
                });
    }

    function activateTableFeatures(args) {
        exercise3(args);
        exercise4(args);
        exercise5(args);
        exercise6(args);
        addPaginationBehavior(args);
    }


    function exercise1() {
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



    function addPaginationBehavior(args) {
        var container = args.container;
        var pagination = container.find('.pagination');
        pagination.on('click', 'li[data-id]', function () {
            var page = parseInt($(this).attr('data-id'));
            args.page = page;
            var generator = new HotelsTableGenerator(args);
            generator.generateTable();
        });
    }

    //exercise2

    function HotelsTableGenerator(args) {
        this.args = args;
    }

    HotelsTableGenerator.prototype.generateTable = function () {
        var container = this.args.container;
        if (this.args.itemsPerPage === null || this.args.itemsPerPage === undefined)
            this.args.itemsPerPage = 10;
        if ((this.args.page === undefined || this.args.page === null))
            this.args.page = 1;
        this.args.hotels.list = [];
        //  $(container).empty();
        generatePageOfTable(this.args);
    };


    function generatePageOfTable(args) {
        args.hotels.list = [];
        (function (args) {
            $.ajax({
                url: 'http://localhost:50581/api/Hotels/GetHotels' + '?' + $.param({
                    Page: args.page,
                    PageSize: args.itemsPerPage,
                    Name: args.nameToSearch,
                    MaxRating: args.maxRating,
                    MinRating: args.minRating,
                    MinRoomsCount: args.minRoomsCount,
                    MaxRoomsCount: args.maxRoomsCount,
                    City:args.city
                }),
                dataType: 'json',
                success: function (data, status, xhr) {
                    for (var i = 0; i < data.Hotels.length; i++) {
                        var hotel = convertHotelToLocal(data.Hotels[i]);
                        args.hotels.add(hotel);
                    }
                    args.totalItems = data.TotalItems;
                    generateTable(args);
                    activateTableFeatures(args);
                },
                error: function (xhr, status, error) {
                    alert("Fail load hotels! \n" + error);
                }
            });
        })(args);
    }

    function generatePaginationContainer(args) {
        var tableContainer = args.container;
        var paginationList = tableContainer.append('<div class="paginare"><ul class="pagination"></ul></div>').find('ul');
        var nrPages = 0;
        var itemsPerPage = args.itemsPerPage;

        nrPages = parseInt(args.hotels.list.length / itemsPerPage) + 1;
        paginationList.append('<li>«</li>');
        for (var i = 1 ; i <= nrPages ; i++) {
            if (args.page === i) {
                paginationList.append('<li class="active" data-id=' + i + '>' + i + '</li>');
            } else {
                var itemList = $('<li></li>');
                itemList.attr('data-id', i);
                itemList.text(i);
                paginationList.append(itemList);
            }
        }
        paginationList.append('<li>»</li>');
    }

    function generatePaginationContainerApi(args) {
        var tableContainer = args.container;
        var paginationList = tableContainer.append('<div class="paginare"><ul class="pagination"></ul></div>').find('ul');
        var nrPages = 0;
        var itemsPerPage = args.itemsPerPage;
        nrPages = parseInt(args.totalItems / args.itemsPerPage);
        paginationList.append('<li>«</li>');
        for (var i = 1; i <= nrPages; i++) {
            if (args.page === i) {
                paginationList.append('<li class="active" data-id=' + i + '>' + i + '</li>');
            } else {
                var itemList = $('<li></li>');
                itemList.attr('data-id', i);
                itemList.text(i);
                paginationList.append(itemList);
            }
        }
        paginationList.append('<li>»</li>');
        
    }

    function generateTable(args) {
        var container;
        container = args.container;
        var divTemp = $('<div/>');
        if (args.page === undefined || args.page === null) {
            args.page = 1;
        }
        if (args.itemsPerPage === undefined || args.itemsPerPage === null) {
            args.itemsPerPage = 10;
        }
        if (args.columns === null || args.columns === undefined) {
            divTemp = divTemp.append('<table><thead><th>ID</th><th>Name</th><th>Description</th><th>City</th><th>Rooms Count</th><th>Rating</th><th>Operations</th></thead></table>');
        } else {
            var table = '<table><thead>';
            for (var i = 0 ; i < args.columns.length; i++) {
                table += '<th>' + args.columns[i].header + '</th>';
            }
            table += '</thead></table>';
            divTemp = args.container.append(table);
        }
        var tableHotels = $(divTemp).find('table');
        //var itemsPage = getItemsPage(args);
        var tbody = tableHotels.append('<tbody></tbody>').find('tbody');
        for (var i = 0 ; i < args.hotels.list.length ; i++) {
            tbody.append(createRow(args.hotels.list[i], args.columns));
        }
        $(divTemp).append('<input id=\'addButton\' type=\'button\' value=\'Add\'/>')
                    .append('<input id=\'btnLoad\' type=\'button\' value=\'Load\'/>');
        $(divTemp).append('<input id="inputLoad" type="url" placeholder="adress content"/>');
        container.html(divTemp.html());
        //generatePaginationContainer(args);
        generatePaginationContainerApi(args);
    }

    function generateStarsRating(numberOfStars) {
        var star = '<span>☆</span>';
        var divRating = '<div class="rating">';
        for (var i = 0 ; i < numberOfStars ; i++) {
            divRating += star;
        }
        divRating += '</div>';
        return divRating;
    }


    function getItemsPage(args) {
        var startItem = args.itemsPerPage * (args.page - 1);
        if (startItem > args.hotels.list.length)
            startItem = 0;
        var endItem = args.itemsPerPage * args.page;
        if (endItem > args.hotels.list.length) {
            endItem = args.hotels.list.length
        }
        var itemsPage = args.hotels.list.slice(startItem, endItem);
        return itemsPage;
    }

    function createRow(hotel, columns) {
        var row = '';
        row += '<tr data-id=\'' + hotel.id + '\'>';
        var cell = '';
        if (columns === null || columns === undefined) {
            cell += '<td>' + hotel.id + '</td>';
            cell += '<td>' + hotel.name + '</td>';
            cell += '<td>' + hotel.description + '</td>';
            cell += '<td>' + hotel.city + '</td>';
            cell += '<td>' + hotel.rooms_count + '</td>';
            cell += '<td>' + generateStarsRating(hotel.stars_count) + '</td>';
            cell += '<td><input type=\'button\' class=\'btnDelete\' value=\'Delete\'/> <input type=\'button\' class=\'btnEdit\' value=\'Edit\'/></td>';
            row += cell;
        }
        else {
            for (var i = 0; i < columns.length; i++) {
                cell += '<td>' + hotel[columns[i].field] + '</td>';
                if (columns[i].field.toLowerCase() === 'operations') {
                    cell += '<td><input type=\'button\' class=\'btnDelete\' value=\'Delete\'/> <input type=\'button\' class=\'btnEdit\' value=\'Edit\'/></td>';
                }
                if (columns[i].field.toLowerCase() === 'stars_count') {
                    var numberOfStars = hotel.stars_count;
                    cell += generateStarsRating(numberOfStars);
                }

            }
            row += cell;
            row += '</tr>';

        }
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
        var btnAdd = container.find('#addButton');
        $(btnAdd).click(function () {
            var tbody = $(container).find('tbody').prepend(createInputsRow(args.columns));
            $.get('api/Hotels/GetValidId',
                    function (data) {
                        $(tbody).find('input[data-id=id]').val(data);
                    });
                    
            $(tbody).find('#btnConfirm').click(function () {
                var hotel = getHotelFromRow($(this).closest('tr'));
                try {
                    //args.hotels.add(hotel);
                    var hotelToSend = convertHotel(hotel);
                    $.post({
                        url: 'http://localhost:50581/api/Hotels/Add',
                        data: hotelToSend,
                        success: function (data, status, xhr) {
                            refreshTableWithUrl(args);
                        },
                        error: function (xhr, status, err) {
                            alert("Fail to add hotel! \n" + xhr.responseText);
                        }
                    });
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

    function getHotelFromRow(context) {
        var hotel = new Hotel();
        hotel.id = parseInt($('input[data-id=id]', context).val());
        hotel.name = $('input[data-id=name]', context).val();
        hotel.description = $('input[data-id=description]', context).val();
        hotel.city = $('input[data-id=city]', context).val();
        hotel.rooms_count = $('input[data-id=rooms_count]', context).val();
        hotel.stars_count = $('input[data-id=stars_count]', context).val();
        return hotel;
    }


    // exercise 4
    function exercise4(args) {
        var btnDelete = args.container.find('.btnDelete');

        btnDelete.on('click', function () {
            var currentRow = $(this).closest('tr');
            var hotelID = parseInt(currentRow.attr('data-id'));
            var response = confirm("Do you want to delete this hotel?");
            if (response === true) {
                //args.hotels.delete(hotelID);
                $.ajax({
                    url: 'http://localhost:50581/api/Hotels/Delete' +
                        '?' +
                        $.param({
                            "id": hotelID
                        }),
                    type: 'DELETE',
                    success: function (data, status, xhr) {
                        refreshTableWithUrl(args);
                    },
                    error: function (xhr, status, err) {
                        alert("Canot delete! \n" + err);
                    }

                });

            }

        });
    }



    function createInputsRow(columns) {
        var row = '<tr>';
        if (columns === undefined || columns === null) {
            row += '<td><input data-id="id" type="number"/></td>';
            row += '<td><input data-id="name" type="text"/></td>';
            row += '<td><input data-id="description" type="text"></td>';
            row += '<td><input data-id="city" type="text"/></td>';
            row += '<td><input data-id="rooms_count" type=\'number\'/></td>';
            row += '<td><input data-id=\'stars_count\' type=\'number\'/></td>';
            var divOp = createDivOperations();
            row += '<td>' + divOp;
            row += '</td>';
        } else {
            for (var i = 0 ; i < columns.length; i++) {
                if (columns[i].type === undefined || columns[i].type === null) {
                 
                    if (columns[i].toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].type + 'type="text" /></td>';
                    }
                    else {
                        row += '<td>' + createDivOperations() + '</td>';
                    }

                } else {
                    if (columns[i].field.toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].field + 'type=' + columns[i].type + '/></td>';
                    } else {
                        row += '<td>' + createDivOperations() + '</td>';
                    }
                }
            }
        }
        row += '</tr>';
        return row;
    }

    function createEditRow(hotel, columns) {
        var row = '<tr data-id="' + hotel.id + '">';
        if (columns === undefined || columns === null) {
            row += '<td><input data-id=\'id\' value=\'' + hotel.id + '\' type=\'number\' readonly /></td>';
            row += '<td><input data-id=\'name\' value=\'' + hotel.name + '\' type=\'text\'/></td>';
            row += '<td><input data-id=\'description\' value=\'' + hotel.description + '\' type=\'text\'/></td>';
            row += '<td><input data-id=\'city\' value=\'' + hotel.city + '\' type=\'text\'/></td>';
            row += '<td><input data-id=\'rooms_count\' value=\'' + hotel.rooms_count + '\' type=\'number\'/></td>';
            row += '<td><input data-id=\'stars_count\' value=\'' + hotel.stars_count + '\' type=\'number\'/></td>';
            var divOp = createDivOperations();
            row += '<td>' + divOp;
            row += '</td>';
        } else {
            for (var i = 0 ; i < columns.length; i++) {
                if (columns[i].type === undefined || columns[i].type === null) {
                    if (columns[i].toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].field + 'value=\'' + hotel[columns[i].field] + '\' type="text" readonly /></td>';
                    }
                    else {
                        row += '<td>' + createDivOperations() + '</td>';
                    }

                } else {
                    if (columns[i].field.toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].field + 'value=\'' + hotel[columns[i].field] + '\' type="' + columns[i].type + ' readonly /></td>';
                    } else {
                        row += '<td>' + createDivOperations() + '</td>';
                    }
                }
            }
        }

        row += '</tr>';
        return row;
    }

    //covert Hotel

    function convertHotel(hotel) {
        var hotelToSend = {
            Id: hotel.id,
            City: hotel.city,
            Description: hotel.description,
            Name: hotel.name,
            Rating: hotel.stars_count,
            RoomsCount: hotel.rooms_count
        };
        return hotelToSend;
    }

    function convertHotelToLocal(hotel) {
        var hotelToSend = {
            id: hotel.Id,
            city: hotel.City,
            description: hotel.Description,
            name: hotel.Name,
            stars_count: hotel.Rating,
            rooms_count: hotel.RoomsCount
        };
        return hotelToSend;
    }


    //exercise5
    function exercise5(args) {
        args.container.on('click', '.btnEdit', function () {
            var restoreRow = $(this).closest('tr').html();
            var tr = $(this).closest('tr');
            var hotelToEdit = args.hotels.getHotelById(parseInt(tr.attr('data-id')));
            tr.replaceWith(createEditRow(hotelToEdit, args.columns));
            var tbody = args.container.find('tbody');
            tbody.on('click', '#btnConfirm', function () {
                var currentRow = $(this).closest('tr');
                var editedHotel = getHotelFromRow(currentRow);
                var hotelToSend = convertHotel(editedHotel);
                $.post({

                    url: 'http://localhost:50581/api/Hotels/Update',
                    data: hotelToSend,
                    success: function (data, status) {
                        refreshTableWithUrl(args);
                    },
                    error: function (xhr, status, err) {
                        alert("Cannot update hotel! \n" + xhr.responseText);
                    }
                });

            });
            tbody.on('click', '#btnCancel', function () {
                tr = $(this).closest('tr');
                tr.html(restoreRow);
            });
        });

    }


    //exercise 6
    function exercise6(args) {
        var container = args.container;
        var btnLoad = args.container.find("#btnLoad");
        $(btnLoad).on('click', function () {

            var url = container.find('#inputLoad').val();
            if (url) {
                args.url = url;
            }
            loadTable(args);
        });
    }



    function filterOption() {
        var op = $('.filter select').val();
    }


    function createDivOperations() {
        var div = '<div>';
        div += '<input type=\'button\' value=\'Confirm\' id=\'btnConfirm\'/>';
        div += '<input type=\'button\' value=\'Cancel\' id=\'btnCancel\'/>';
        div += '</div>'
        return div;
    }

    //exercise 7

    function refreshTable(args) {
        var generator = new HotelsTableGenerator(args);
        generator.generateTable();
    }

    function refreshTableWithUrl(args) {
        args.hotels.list = [];
        var generator = new HotelsTableGenerator(args);
        generator.generateTable();
    }

    function loadTable(args) {
        // args.container.empty();
        var generator = new HotelsTableGenerator(args);
        generator.generateTable();
    }


    function exercise7(args) {
        var inputSearch = $('#search');
        var btnClear = $('#btnClear');
        btnClear.click(function () {
            alert("clear");
            refreshTable(args);
        });
        inputSearch.on('input', function (e) {
            var nameHotel = inputSearch.val();
            args.page = 1;
            args.nameToSearch = nameHotel;
            var generator = new HotelsTableGenerator(args);
            generator.generateTable();
        });
        var searchContainer = $('.container-3');
        searchContainer.on('click', '#btnSearch', function () {

            var nameHotel = inputSearch.val();
            filterDom(nameHotel, args, 1);
        });
    }


    function filterDom(key, args, column) {
        var container = args.container;
        container.find('tr[data-id]').each(function () {
            var cellData = $(this).find('td:eq(' + column + ')').text();
            if (cellData.toUpperCase().includes(key.toUpperCase().trim())) {
                $(this).show();
            }
            else {
                $(this).hide();
            }

        });
    }

    function filterElements(key, args, column) {
        var container = args.container;
        var filtredHotels = new Hotels();
        filtredHotels.list = args.hotels.filter(key, column);
        var filtredHotelsArgs = {
            container: args.container,
            hotels: filtredHotels,
            page: args.page,
            itemsPerPage: args.itemsPerPage,
            columns: args.columns
        }
        var generator = new HotelsTableGenerator(filtredHotelsArgs);
        generator.generateTable();
    }

    function filterRange(min, max, args, column) {
        var container = args.container;
        container.find('tr[data-id]').each(function () {
            var cellData = parseInt($(this).find('td:eq(' + column + ')').text());
            if (min <= cellData && max >= cellData) {
                $(this).show();
            }
            else {
                $(this).hide();
            }

        });
    }

})();