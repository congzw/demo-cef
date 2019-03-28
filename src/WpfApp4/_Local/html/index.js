(function (window, $) {
    'use strict';
    var show = function (message) {
        var $message = $("#message");
        var theDate = new Date().toLocaleString();
        $message.html('<h2>js call: ' + message + ' => ' + theDate + '</h2>');
    };

    var cefHost = window.cefHost;
    window.indexVo = {};
    indexVo.changeFontSize = function () {
        show('changeFontSize');
        cefHost.changeFontSize();
    };
    indexVo.navigate = function (name) {
        show('navigate to ' + name);
        cefHost.navigate(name);
    };
}(window, jQuery));