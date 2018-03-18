function viewport() {
    var e = window, a = 'inner';
    if (!('innerWidth' in window)) {
        a = 'client';
        e = document.documentElement || document.body;
    }
    return { width: e[a + 'Width'], height: e[a + 'Height'] };
}

function is_touch_device() {
    return (('ontouchstart' in window)
         || (navigator.MaxTouchPoints > 0)
         || (navigator.msMaxTouchPoints > 0));
}

$(document).ready(function () {
    //Toggle
    $(".js-toggle-class").click(function (e) {
        e.preventDefault();
        $this = $(this);
        target = $this.data("target");
        tclass = $this.data("class");
        $("#js-" + target).toggleClass(tclass);
        $this.toggleClass("active");
    });
});