var currentDateTime = new Date();

currentDateTime.setDate(currentDateTime.getDate() + 1);
var dateTomorrow = getStringDate(currentDateTime);

currentDateTime.setDate(currentDateTime.getDate() + 1);
var dateAfterTomorrow = getStringDate(currentDateTime);

var checkinElem = document.querySelector("#checkIn");
var checkoutElem = document.querySelector("#checkOut");

checkinElem.setAttribute("min", dateTomorrow);
checkoutElem.setAttribute("min", dateAfterTomorrow);

checkinElem.onchange = function () {
    var d = new Date(this.value);
    d.setDate(d.getDate() + 1);

    var date = getStringDate(d);

    checkoutElem.setAttribute("min", date);
}

checkoutElem.onchange = function () {
    var d = new Date(this.value);
    d.setDate(d.getDate() - 1);

    var date = getStringDate(d);

    checkinElem.setAttribute("max", date);
}


function getStringDate(date) {
    var year = date.getFullYear();
    var month = (date.getMonth() + 1);
    var day = date.getDate();

    if (day < 10) {
        day = '0' + day;
    }

    if (month < 10) {
        month = '0' + month;
    }

    var stringDate = year + "-" + month + "-" + day;

    return stringDate;
}
