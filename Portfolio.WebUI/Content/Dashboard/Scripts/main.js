$(function(){
    var sPath = window.location.pathname;
    var sPage = sPath.substring(sPath.indexOf('/') + 1);
    $('a[href="/'+ sPage +'"]').parent().addClass('active');
});

function viewport() {
    var e = window, a = 'inner';
    if (!('innerWidth' in window)) {
        a = 'client';
        e = document.documentElement || document.body;
    }
    return { width: e[a + 'Width'], height: e[a + 'Height'] };
}

if (viewport().width < 768) {
    $("#main-wrapper").removeClass("menu-view");
}

function is_touch_device() {
    return (('ontouchstart' in window)
         || (navigator.MaxTouchPoints > 0)
         || (navigator.msMaxTouchPoints > 0));
}

$(document).ready(function () {
    $("#js-toggle-menu").click(function () {
        $("#main-wrapper").toggleClass("menu-view");
    });

    $(window).resize(function () {
        if (viewport().width < 768) {
            $("#main-wrapper").removeClass("menu-view");
        } else {
            $("#main-wrapper").addClass("menu-view");
        }
    });

    if (!is_touch_device()) {
        $('body').addClass("non-touch");
    } else {
        $('body').addClass("touchscreen");
    }

    $(".js-dropdown").click(function (e) {
        e.preventDefault();
        if (is_touch_device()) {
            $this = $(this);
            $this.parent().toggleClass("active-open");
            target = $this.data("target");
            $("#js-" + target).toggleClass("open");
        }
    });

});


