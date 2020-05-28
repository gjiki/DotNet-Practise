$(document).ready(function () {
    $("#fromCurrencyElem,#toCurrencyElem").change(function () {
        var from = $("#fromCurrencyElem").val();
        var to = $("#toCurrencyElem").val();
        if (from && to) {
            var data = {};
            data.FromCurrency = from;
            data.ToCurrency = to;
            $.ajax({
                type: "POST",
                url: "/Calculator/Rate",
                data: '{data: ' + JSON.stringify(data) + '}',
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    $("#rateInput").val(data);
                },
                error: function () {
                    alert("error while inserting data!");
                }
            });
            alert("Seisburqi?");
        }
    });
});