function Resize() {
    var header = $("#header").outerHeight();
    var locate = $("#locate").outerHeight();
    var content = $("#content");
    content.height($(window).height() - header - locate -43);
    content.width($(window).width());
}