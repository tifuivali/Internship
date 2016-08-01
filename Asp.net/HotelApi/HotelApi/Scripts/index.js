
// Page Ready

$(document).ready(function () {

    var args = {
        hotels: new Hotels(),
        container: $('#list_hotels'),
        url: host + '/api/Hotels',
        enableModify:true,
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