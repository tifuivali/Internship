
// Page Ready

$(document).ready(function () {


    grid();

    $(".k-grid-Add", "#list_hotels2").bind("click", function (ev) {
        // your code
        $("#list_hotels2").add();
    });

    var args = {
        hotels: new Hotels(),
        container: $('#list_hotels'),
        url: host + '/api/Hotels',
        enableModify: true,
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


function grid() {
    $("#list_hotels2")
        .kendoGrid({
            toolbar: ["pdf", {
                template: '<button class="k-button k-button-icontext k-grid-Add" value="ADD NEW RECORD">ADD NEW RECORD</button>',
                text: "Add new record",
                click: function (e) { alert("foo"); return false; }
            }],
            dataSource: {
                type: "json",
                transport: {
                    create: {
                        url: "http://localhost/Hotels/api/Hotels/Add",
                        dataType: "jsonp" // "jsonp" is required for cross-domain requests; use "json" for same-domain requests
                    },
                    update: function (options) {
                        $.post({
                            url: "http://localhost/Hotels/api/Hotels/Update",
                            dataType: "jsonp", // "jsonp" is required for cross-domain requests; use "json" for same-domain requests
                            // send the updated data items as the "models" service parameter encoded in JSON
                            data: {
                                Hotel: options.data.models.fields
                            },
                            success: function (result) {
                                // notify the data source that the request succeeded
                                options.success(result);
                            },
                            error: function (result) {
                                // notify the data source that the request failed
                                options.error(result);
                            }
                        });
                    },
                    read: "http://localhost/Hotels/api/Hotels/GetHotels",
                    parameterMap: function (data, type) {
                        return {
                            take: data.take,
                            skip: data.skip,
                            page: data.page,
                            pageSize: data.pageSize,
                            filter: kendo.stringify(data.filter)
                        };
                    }
                },
                schema: {
                    data: "Hotels",
                    total: "TotalItems",
                    model: {
                        id: "Id",
                        fields: {
                            Id: { type: "number" },
                            Name: { type: "string" },
                            Description: { type: "string" },
                            City: { type: "string" },
                            RoomsCount: { type: "number" },
                            Rating: { type: "number" }
                        }
                    }
                },
                pageSize: 20,
                serverPaging: true,
                serverFiltering: true,

                //   serverSorting: true
            },
            pdf: {
                allPages: true,
                author: "Tifui Vali",
                fileName: "Hotels -Export"
            },
            editable: {
                mode: "inline"
            },
            height: 550,
            filterable: true,
            sortable: true,
            pageable: {
                pageSize: 10,
                pageSizes: [10, 20, "All"],
                refresh: true

            },
            columns: [{
                field: "Id",
                title: "Id",
                width: 80
            }, {
                field: "Name",
                title: "Name"
            }, {
                field: "Description",
                title: "Description"
            }, {
                field: "City",
                title: "City",
                width: 150
            }, {
                field: "RoomsCount",
                title: "Rooms",
                width: 200
            }, {
                field: "Rating",
                title: "Rating",
                width: 100
            }, {
                command: "edit",
                width: 100
            },
            {
                command: "delete",
                width: 150
            }]
        });
}