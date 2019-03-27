(function (window, $) {
    'use strict';
    var show = function (message) {
        var $message = $("#message");
        var theDate = new Date().toLocaleString();
        $message.html('<h2>js call: ' + message + ' => ' + theDate + '</h2>');
    };
    var mainWindowVo = window.mainWindowVo;
    window.indexVo = {};
    indexVo.showMessage = function () {
        show('showMessage');
        mainWindowVo.showMessage('showMessage called from javascript!');
    };
    indexVo.changeColor = function () {
        show('changeColor');
        mainWindowVo.changeColor();
    };
}(window, jQuery));