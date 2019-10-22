$("#BandDropdown").change(function () {
    var selected = $(this).val();

    if (selected != '') {
        $("#resistor-section").load(bandUrl, { id: selected });
    }
    else {
        $("#resistor-section").empty();
    }

    return false;
});

function calculate() {
    var count = $("#count").val();
    var arrayList = new Array(count);

    for (var i = 0; i < count; i++) {

        var id = "#" + i.toString();
        var value = $(id).val();

        if (value != '') {
            arrayList[i] = value;
        }
    }

    if (arrayList.length == count) {
        $("#BandDropdown").val("");
        $("#resistor-section").load(calcUrl, { value: arrayList.join(",") });
    }
    else {
        alert("All Bands Must Be Selected Before Calculation Can Begin.");
    }

    return false;
}