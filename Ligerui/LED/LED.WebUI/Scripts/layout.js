$(window).resize(function () {
    AllResize();
});

$(document).ready(function () {
    AllResize();
});

function AllResize() {
    if (typeof (Resize) == "function") {
        Resize();
    }
}