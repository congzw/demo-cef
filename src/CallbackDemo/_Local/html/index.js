(function (window, $) {
    'use strict';
    var show = function (message) {
        var $message = $("#message");
        var theDate = new Date().toLocaleString();
        $message.html('<h2>js call: ' + message + ' => ' + theDate + '</h2>');
        console.log('js call: ' + message);
    };
    var mainWindowVo = window.mainWindowVo;
    window.indexVo = function() {

        var message = '';
        var callTimes = 0;

        var successFunc = function (messageResult) {
            message = messageResult.Message;
            show(message + (++callTimes));
        }

        var failFunc = function (messageResult) {
            message = messageResult.Message;
            show(message + (++callTimes));
        }

        return {
            foo: function (shouldSuccess) {
                mainWindowVo.fooWithCallback({ ShouldSuccess: shouldSuccess }, successFunc, failFunc);
            },
            Foo: function (shouldSuccess) {
                mainWindowVo.FooWithCallback({ ShouldSuccess: shouldSuccess }, successFunc, failFunc);
            }
        };

    }();

}(window, jQuery));