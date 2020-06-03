$(document).ready(function () {
    $("#fromCurrencyElem,#toCurrencyElem").change(function () {
        var from = $("#fromCurrencyElem").val();
        var to = $("#toCurrencyElem").val();
        if (from && to) {
            $.ajax({
                type: "POST",
                url: "/Calculator/Rate",
                dataType : 'json',
                data: {
                    'fromCurrency': from,
                    'toCurrency' : to
                },
                success: function (data) {
                    $("#rateInput").val("" + data);
                },
                error: function () {
                    alert("error while inserting data!");
                }
            });
        }
    });

    $("#buyAmountInput").change(function () {
        var buy = $("#buyAmountInput").val();
        if (buy != '0.00' && buy != null && buy != NaN) {
            var rate = $("#rateInput").val();
            if (rate != '0.00' && rate != null && rate != NaN) {
                $("#sellAmountInput").val("" + (buy * rate));
            }
        }
    });

    $("#sellAmountInput").change(function () {
        var sell = $("#sellAmountInput").val();
        if (sell != '0.00' && sell != null && sell != NaN) {
            var rate = $("#rateInput").val();
            if (rate != '0.00' && rate != null && rate != NaN) {
                $("#buyAmountInput").val("" + (sell * rate));
            }
        }
    });
});