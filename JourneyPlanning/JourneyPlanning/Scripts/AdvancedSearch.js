$(document).ready(function () {
    $("#outwardDate").datepicker({
        numberOfMonths: 2,
        minDate: 0,
        maxDate: +91,
        dateFormat: 'dd/mm/y',
        defaultDate: null
    });

    $("#returnDate").datepicker({
        numberOfMonths: 2,
        minDate: 0,
        maxDate: +91,
        dateFormat: 'dd/mm/y',
        defaultDate: null
    });
});
