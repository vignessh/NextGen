$(document).ready(function () {
    $("#OutwardDate").datepicker({
        numberOfMonths: 2,
        minDate: 0,
        maxDate: +91,
        dateFormat: 'dd/mm/y',
        defaultDate: null
    });

    $("#ReturnDate").datepicker({
        numberOfMonths: 2,
        minDate: 0,
        maxDate: +91,
        dateFormat: 'dd/mm/y',
        defaultDate: null
    });

    $("#journeyType").change(function () {
        var selectedJourneyType = $("#journeyType option:selected")[0].value;
        if (selectedJourneyType == "R")
            $("#returnDateDiv").show();
        else
            $("#returnDateDiv").hide();
    });

    $("#OriginStation").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "GET",
                //contentType: "application/json; charset=utf-8",
                url: "/JourneyPlanning/PredictiveSearch?keywordStartsWith=" + request.term,
                dataType: "json",
                async: true,
                success: function (data) {
                    response(data);
                },
                error: function (result) {
                    alert("Due to unexpected errors we were unable to load data");
                }
            });
        },
        minLength: 3
    });

    $("#DestinationStation").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "GET",
                //contentType: "application/json; charset=utf-8",
                url: "/JourneyPlanning/PredictiveSearch?keywordStartsWith=" + request.term,
                //data: "{'keywordStartsWith':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response(data);
                },
                error: function (result) {
                    alert("Due to unexpected errors we were unable to load data");
                }
            });
        },
        minLength: 3
    });

    $("#ViaAvoidStation").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "GET",
                //contentType: "application/json; charset=utf-8",
                url: "/JourneyPlanning/PredictiveSearch?keywordStartsWith=" + request.term,
                //data: "{'keywordStartsWith':'" + request.term + "'}",
                dataType: "json",
                async: true,
                success: function (data) {
                    response(data);
                },
                error: function (result) {
                    alert("Due to unexpected errors we were unable to load data");
                }
            });
        },
        minLength: 3
    });
});
