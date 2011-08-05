var searchBox = null;
var searchButton = null;
var validationSummary = null;
var addressRegexp = /^\s*([^,]+)\s+(\d{1,5})\s*((,\s*[^,]+\s*){2,3})$/;
var commaRegexp = /^\s*(.+)\s*$/;
var EMPTY_SEARCH = "Please enter your address (example: Maggiolo 520, Montevideo, Uruguay)";
var WRONG_FORMAT = "Please enter your address correctly (example: Maggiolo 520, Montevideo, Uruguay)";

function validateSearch() {
    if (searchBox.val().length == 0) {
        validationSummary.text(EMPTY_SEARCH).show(200);
        return false;
    }
    var match = addressRegexp.exec(searchBox.val());
    if (match) {
        $("#Number").val(match[2]);
        $("#Street").val(match[1]);
        var temp = match[3].split(",");
        if (temp.length > 3) {
            match = commaRegexp.exec(temp[1]);
            $("#City").val(match[1]);
            match = commaRegexp.exec(temp[2]);
            $("#State").val(match[1]);
            match = commaRegexp.exec(temp[3]);
            $("#Country").val(match[1]);
        } else {
            match = commaRegexp.exec(temp[1]);
            $("#City").val(match[1]);
            $("#State").val(match[1]);
            match = commaRegexp.exec(temp[2]);
            $("#Country").val(match[1]);
        }
        return true;
    } else {
        validationSummary.text(WRONG_FORMAT).show(200);
        return false;
    }
}

function focusIn() {
    searchBox.removeClass("blurry");
}

function focusOut() {
    if (searchBox.val().length == 0) {
        searchBox.addClass("blurry");
    }
}

$(document).ready(function () {
    validationSummary = $("#validationSummary");
    searchBox = $("#txtSearchBox");
    searchBox.focus(focusIn).focusout(focusOut);
    searchButton = $("#btnSearch").click(validateSearch);
    focusOut();
});    