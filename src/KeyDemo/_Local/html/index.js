(function (window, $) {
    'use strict';
    var show = function (message) {
        var $message = $("#message");
        var theDate = new Date().toLocaleString();
        $message.html('<h2>js call: ' + message + ' => ' + theDate + '</h2>');
        console.log('js call: ' + message);
    };
    var mainWindowVo = window.mainWindowVo;
    
    $(document).ready(function () {
        show("document ready");
    });

    window.indexVo = function() {
        return {
            refresh: function () {
                window.location.reload(true);
                show("hard refresh");
            }
        };

    }();

}(window, jQuery));