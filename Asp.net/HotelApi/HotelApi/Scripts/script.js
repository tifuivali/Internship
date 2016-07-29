/// <reference path="jquery-2.1.0-vsdoc.js" />

(function () {
    "use strict";

    var host = 'http://localhost/Hotels';
    //Create new Hotel object
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

    //Create new Hotels List
    function Hotels() {
        this.list = [];

    }

    //Get Length of hotel list
    Hotels.prototype.length = function () {
        return this.list.length;
    }

    //Add new hotels to hotel List
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


    //Update sfecific item of hotel list
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


    //Delete item from hotel list
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

    //Get item by id from hotel list
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

    //Get information (string) of specified hotel from hotel list
    Hotels.prototype.getInfo = function (id) {
        for (var item in this.list) {
            if (this.list[item].id === id) {
                return this.list[item].name + "-" + this.list[item].city + "-" + this.list[item].stars_count + " stele";
            }
        }
    }

    //Get all information ([strinmg]) of all items
    Hotels.prototype.getAllInfo = function () {
        var infos = [];
        for (var item in this.list) {
            infos.push(this.getInfo(this.list[item].id));
        }
        return infos;
    };


    //Return items by specified index
    Hotels.prototype.get = function (index) {
        return this.list[index];
    }



    // Page Ready

    $(document).ready(function () {

        var args = {
            hotels: new Hotels(),
            container: $('#list_hotels'),
            url: host+'/api/Hotels',
            page: 1,
        };

        //activate Filter Page
        addFilterBehavior(args);

        //activate search
        addSearchBehavior(args);

        //activate pagination
        addNumberOfPageBehavior(args);

        //generate Table
        var generator = new HotelsTableGenerator(args);
        generator.generateTable();;
    });



    //Filter
    function addFilterBehavior(args) {
        $('.filterContent-expanded').hide();
        $('.filterContent-expanded button[value=x]')
            .click(function () {
                $('.filterContent-expanded').hide();
            });
        $('.filterContent input[name=filter]')
            .click(function () {
                $('.filterContent-expanded').show();
                generateHtmlOptionsCity();
            });
        $('section')
            .click(function () {
                $('.filterContent-expanded').hide();
            });
        $('.filterContent input[name=clear')
            .click(function () {
                args.city = undefined;
                args.itemsPerPage = parseInt($('.numberOfPage select').val());
                args.page = 1;
                args.nameToSearch = undefined;
                args.minRating = undefined;
                args.maxRating = undefined;
                args.minRoomsCount = undefined;
                args.maxRoomsCount = undefined;
                refreshTableWithUrl(args);
            });

        $('.filterContent-expanded input[name=filter]')
            .click(function () {
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

    //add List of city
    function addListOfCity(html) {
        $('.filterContent-expanded select').html(html);
    }

    //generateHtmlOptionsCity

    function generateHtmlOptionsCity() {
        var html = '<option value="">None</option>';
        $.get(host + '/api/Hotels/GetListOfCity',
            function (data) {
                for (var i = 0; i < data.length; i++) {
                    html += '<option value="' + data[i] + '">' + data[i] + '</option>';
                }
                addListOfCity(html);
            });
    }


    //Number of page behavior 
    function addNumberOfPageBehavior(args) {
        $('.numberOfPage select').change(
                function () {
                    var itemsPerPage = parseInt($(this).val());
                    args.itemsPerPage = itemsPerPage;
                    var gen = new HotelsTableGenerator(args);
                    gen.generateTable();
                });
    }

    //Activate All Table Behaviors
    function activateTableFeatures(args) {
        addItemBehavior(args);
        deleteItemBehavior(args);
        editItemBehavior(args);
        loadFileBehavior(args);
        tablePaginationBehavior(args);
    }


    //table Pagination Behavior
    function tablePaginationBehavior(args) {
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


    //generate Table with specified parameters args
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


    //get specified page from url and generte table 
    //is used in generor object at function generateTable
    function generatePageOfTable(args) {
        args.hotels.list = [];
        (function (args) {
            $.ajax({
                url: host+'/api/Hotels/GetHotels' + '?' + $.param({
                    Page: args.page,
                    PageSize: args.itemsPerPage,
                    Name: args.nameToSearch,
                    MaxRating: args.maxRating,
                    MinRating: args.minRating,
                    MinRoomsCount: args.minRoomsCount,
                    MaxRoomsCount: args.maxRoomsCount,
                    City: args.city
                }),
                dataType: 'json',
                success: function (data, status, xhr) {
                    for (var i = 0; i < data.Hotels.length; i++) {
                        var hotel = convertHoteFromExternReprezentationToIntern(data.Hotels[i]);
                        args.hotels.add(hotel);
                    }
                    args.totalItems = data.TotalItems;
                    generateHtmlTable(args);
                    activateTableFeatures(args);
                },
                error: function (xhr, status, error) {
                    alert("Fail load hotels! \n" + error);
                }
            });
        })(args);
    }


    //generate html code for pagination 
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

    //generate Html Code for table
    function generateHtmlTable(args) {
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
            tbody.append(createHtmlRowTable(args.hotels.list[i], args.columns));
        }
        $(divTemp).append('<input id=\'addButton\' type=\'button\' value=\'Add\'/>')
                    .append('<input id=\'btnLoad\' type=\'button\' value=\'Load\'/>');
        $(divTemp).append('<input id="inputLoad" type="url" placeholder="adress content"/>');
        container.html(divTemp.html());
        //generatePaginationContainer(args);
        generatePaginationContainerApi(args);
    }


    //generate Html code for hotel stars rating 
    function generateHtmlStarsRating(numberOfStars) {
        var star = '<span>☆</span>';
        var divRating = '<div class="rating">';
        for (var i = 0 ; i < numberOfStars ; i++) {
            divRating += star;
        }
        divRating += '</div>';
        return divRating;
    }

    //generate Html Code for a row of table
    //hotel - containing data row
    //columns - columns definition of table 
    function createHtmlRowTable(hotel, columns) {
        var row = '';
        row += '<tr data-id=\'' + hotel.id + '\'>';
        var cell = '';
        if (columns === null || columns === undefined) {
            cell += '<td>' + hotel.id + '</td>';
            cell += '<td>' + hotel.name + '</td>';
            cell += '<td>' + hotel.description + '</td>';
            cell += '<td>' + hotel.city + '</td>';
            cell += '<td>' + hotel.rooms_count + '</td>';
            cell += '<td>' + generateHtmlStarsRating(hotel.stars_count) + '</td>';
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
                    cell += generateHtmlStarsRating(numberOfStars);
                }

            }
            row += cell;
            row += '</tr>';

        }
        return row;
    }


    //add new item behavior
    function addItemBehavior(args) {


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
                    var hotelToSend = convertHotelFromInternReorezentationToExtern(hotel);
                    $.post({
                        url: host+'/api/Hotels/Add',
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


    //retrive a hotel from a specific table row
    //context must be  table or table container
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


    // delete Behavior
    function deleteItemBehavior(args) {
        var btnDelete = args.container.find('.btnDelete');

        btnDelete.on('click', function () {
            var currentRow = $(this).closest('tr');
            var hotelID = parseInt(currentRow.attr('data-id'));
            var response = confirm("Do you want to delete this hotel?");
            if (response === true) {
                //args.hotels.delete(hotelID);
                $.ajax({
                    url: host+'/api/Hotels/Delete' +
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


    //create html code (row of input tags) for adding a hotel
    function createInputsRow(columns) {
        var row = '<tr>';
        if (columns === undefined || columns === null) {
            row += '<td><input data-id="id" type="number"/></td>';
            row += '<td><input data-id="name" type="text"/></td>';
            row += '<td><input data-id="description" type="text"></td>';
            row += '<td><input data-id="city" type="text"/></td>';
            row += '<td><input data-id="rooms_count" type=\'number\'/></td>';
            row += '<td><input data-id=\'stars_count\' type=\'number\'/></td>';
            var divOp = createHtmlDivOperations();
            row += '<td>' + divOp;
            row += '</td>';
        } else {
            for (var i = 0 ; i < columns.length; i++) {
                if (columns[i].type === undefined || columns[i].type === null) {

                    if (columns[i].toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].type + 'type="text" /></td>';
                    }
                    else {
                        row += '<td>' + createHtmlDivOperations() + '</td>';
                    }

                } else {
                    if (columns[i].field.toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].field + 'type=' + columns[i].type + '/></td>';
                    } else {
                        row += '<td>' + createHtmlDivOperations() + '</td>';
                    }
                }
            }
        }
        row += '</tr>';
        return row;
    }

    //create html code (row of input tags) for editing a hotel
    function createEditRow(hotel, columns) {
        var row = '<tr data-id="' + hotel.id + '">';
        if (columns === undefined || columns === null) {
            row += '<td><input data-id=\'id\' value=\'' + hotel.id + '\' type=\'number\' readonly /></td>';
            row += '<td><input data-id=\'name\' value=\'' + hotel.name + '\' type=\'text\'/></td>';
            row += '<td><input data-id=\'description\' value=\'' + hotel.description + '\' type=\'text\'/></td>';
            row += '<td><input data-id=\'city\' value=\'' + hotel.city + '\' type=\'text\'/></td>';
            row += '<td><input data-id=\'rooms_count\' value=\'' + hotel.rooms_count + '\' type=\'number\'/></td>';
            row += '<td><input data-id=\'stars_count\' value=\'' + hotel.stars_count + '\' type=\'number\'/></td>';
            var divOp = createHtmlDivOperations();
            row += '<td>' + divOp;
            row += '</td>';
        } else {
            for (var i = 0 ; i < columns.length; i++) {
                if (columns[i].type === undefined || columns[i].type === null) {
                    if (columns[i].toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].field + 'value=\'' + hotel[columns[i].field] + '\' type="text" readonly /></td>';
                    }
                    else {
                        row += '<td>' + createHtmlDivOperations() + '</td>';
                    }

                } else {
                    if (columns[i].field.toLowerCase() !== 'operations') {
                        row += '<td><input data-id=' + columns[i].field + 'value=\'' + hotel[columns[i].field] + '\' type="' + columns[i].type + ' readonly /></td>';
                    } else {
                        row += '<td>' + createHtmlDivOperations() + '</td>';
                    }
                }
            }
        }

        row += '</tr>';
        return row;
    }


    //Convert a hotel object from intern  reprezentation to extern reprezentation
    function convertHotelFromInternReorezentationToExtern(hotel) {
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

    //Convert a hotel object from extern source to intern reprezentation
    function convertHoteFromExternReprezentationToIntern(hotel) {
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


    //edit Bahavior
    function editItemBehavior(args) {
        args.container.on('click', '.btnEdit', function () {
            var restoreRow = $(this).closest('tr').html();
            var tr = $(this).closest('tr');
            var hotelToEdit = args.hotels.getHotelById(parseInt(tr.attr('data-id')));
            tr.replaceWith(createEditRow(hotelToEdit, args.columns));
            var tbody = args.container.find('tbody');
            tbody.on('click', '#btnConfirm', function () {
                var currentRow = $(this).closest('tr');
                var editedHotel = getHotelFromRow(currentRow);
                var hotelToSend = convertHotelFromInternReorezentationToExtern(editedHotel);
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


    //load File Bahevior
    function loadFileBehavior(args) {
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


    //generateHtml for container with confirm cancel operation
    function createHtmlDivOperations() {
        var div = '<div>';
        div += '<input type=\'button\' value=\'Confirm\' id=\'btnConfirm\'/>';
        div += '<input type=\'button\' value=\'Cancel\' id=\'btnCancel\'/>';
        div += '</div>'
        return div;
    }

    //reload Table (refresh)
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


    //add Search Behavior
    function addSearchBehavior(args) {
        var inputSearch = $('#search');
        inputSearch.on('input', function (e) {
            var nameHotel = inputSearch.val();
            args.page = 1;
            args.nameToSearch = nameHotel;
            var generator = new HotelsTableGenerator(args);
            generator.generateTable();
        });
    }


})();