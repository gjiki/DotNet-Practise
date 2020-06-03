$(document).ready(function () {
    $("#fromCurrencyElem,#toCurrencyElem").change(function () {
        var from = $("#fromCurrencyElem").val();
        var to = $("#toCurrencyElem").val();
        if (from && to) {
            $.ajax({
                type: "POST",
                url: "/Calculator/Rate",
                dataType: 'json',
                data: {
                    'fromCurrency': from,
                    'toCurrency': to
                },
                success: function (data) {
                    $("#rateInput").val("" + data);
                    if (parseFloat($("#buyAmountInput").val()) != 0 && parseFloat($("#sellAmountInput").val()) != 0) {
                        $("#buyAmountInput").val($("#sellAmountInput").val() * $("#rateInput").val());
                    } else if (parseFloat($("#sellAmountInput").val()) != 0) {
                        sellFunc();
                    } else if (parseFloat($("#buyAmountInput").val()) != 0) {
                        buyFunc();
                    }
                },
                error: function () {
                    alert("error while inserting data!");
                }
            });
        }
    });

    $("#buyAmountInput").change(function () {
        buyFunc();
    });

    $("#sellAmountInput").change(function () {
        sellFunc();
    });

    $("#commentInput").change(function () {
        if (parseFloat($("#sellAmountInput").val()) != 0 && parseFloat($("#buyAmountInput").val()) != 0 && parseFloat($("#rateInput").val()) != 0) {
            document.getElementById("submitOperation").disabled = false;
        }
    });

    function buyFunc() {
        var buy = $("#buyAmountInput").val();
        if (buy != '0.00' && buy != null && buy != NaN) {
            var rate = $("#rateInput").val();
            var from = $("#fromCurrencyElem").val();

            if (rate != '0.00' && rate != null && rate != NaN) {
                $("#sellAmountInput").val("" + (buy * rate));
            }
            $.ajax({
                type: "POST",
                url: "/Calculator/GetRate",
                dataType: 'json',
                data: {
                    'fromCurrency': from
                },
                success: function (data) {
                    if (rate != '0.00' && rate != null && rate != NaN) {
                        if (parseFloat($("#sellAmountInput").val()) * data >= 3000 && $("#commentInput").val() == "") {
                            document.getElementById("submitOperation").disabled = true;
                        } else {
                            document.getElementById("submitOperation").disabled = false;
                        }
                    }
                },
                error: function () {
                    alert("error while inserting data!");
                }
            });
        }
    }

    function sellFunc() {
        var sell = $("#sellAmountInput").val();
        if (sell != '0.00' && sell != null && sell != NaN) {
            var rate = $("#rateInput").val();
            var from = $("#fromCurrencyElem").val();

            if (rate != '0.00' && rate != null && rate != NaN) {
                $("#buyAmountInput").val("" + (buy * rate));
            }
            $.ajax({
                type: "POST",
                url: "/Calculator/GetRate",
                dataType: 'json',
                data: {
                    'fromCurrency': from
                },
                success: function (data) {
                    if (rate != '0.00' && rate != null && rate != NaN) {
                        if (parseFloat($("#sellAmountInput").val()) * data >= 3000 && $("#commentInput").val() == "") {
                            document.getElementById("submitOperation").disabled = true;
                        } else {
                            document.getElementById("submitOperation").disabled = false;
                        }
                    }
                },
                error: function () {
                    alert("error while inserting data!");
                }
            });
        }
    }
});