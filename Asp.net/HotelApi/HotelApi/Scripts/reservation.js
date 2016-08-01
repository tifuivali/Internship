

$(document)
    .ready(function () {


        var argsBook = {
            reservations: [],
            container: $("#list_reservations"),
            page: 1,
            columns: [
            { field: 'id', header: 'ID', type: 'number' }, { field: 'city', header: 'Oras', type: 'text' },
            { field: 'name', header: "Nume", type: 'text' },
            { field: 'email', header: "Email", type: 'email' },
            { field: 'phone', header: "Telefon", type: 'text' },
            { field: 'checkin', header: "Data Intrare", type: 'date' },
            { field: 'checkout', header: "Data Iesire", type: 'date' },
            { field: 'operations', header: 'Operatiuni',type: 'text' }
        ]
    };
        generateBooking(argsBook);
        reserve(argsBook);
    });


//table features
function activateTableFeaturesReservations(args) {

    activateEditReservations(args);
}

function getReservationById(id,args) {
    for (var i = 0; i < args.reservations.length; i++) {
        if (args.reservations[i].id === id)
            return args.reservations[i];
    }
}

function activateEditReservations(args) {
    
    args.container.on('click', '.btnEdit', function () {
        var restoreRow = $(this).closest('tr').html();
        var tr = $(this).closest('tr');
        var hotelToEdit =getReservationById(parseInt(tr.attr('data-id')),args);
        tr.replaceWith(createEditRow(hotelToEdit, args.columns));
        var tbody = args.container.find('tbody');
        tbody.on('click', '#btnConfirm', function () {
            var currentRow = $(this).closest('tr');
            var editedHotel = getReservationFrom(currentRow);
            var reservationToSend = convertReservationFromInternReorezentationToExtern(editedHotel);
            $.post({

                url: host+'/api/Booking/Update',
                data: reservationToSend,
                success: function (data, status) {
                    generateBooking(args);
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


    function getReservationFrom(context) {
        var reservation = {};
        reservation.id = parseInt($('input[data-id=id]', context).val());
        reservation.name = $('input[data-id=name]', context).val();
        reservation.email = $('input[data-id=email]', context).val();
        reservation.phone = $('input[data-id=phone]', context).val();
        reservation.checkin = $('input[data-id=checkin]', context).val();
        reservation.checkout = $('input[data-id=checkout]', context).val();
        reservation.city = $('input[data-id=city]', context).val();
        return reservation;
    }

    function convertReservationFromInternReorezentationToExtern(reservation) {
        var reservationToSend = {
            Id: reservation.id,
            City: reservation.city,
            Email: reservation.email,
            Name: reservation.name,
            CheckIN: reservation.checkin,
            CheckOut: reservation.checkout,
            Phone:reservation.phone
        };
        return reservationToSend;
    }
}

