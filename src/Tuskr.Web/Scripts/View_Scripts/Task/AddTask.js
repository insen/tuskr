window.tuskr = window.tuskr || {};

(function (addTask, $, undefined) {
    addTask.init = function (callee, $dialog) {
        $('#submit', $dialog).click(function () {
            $('form', $dialog).submit();
        });
        
        $('#close', $dialog).click(function () {
            $dialog.dialog('close');
            callee.resume();
        });
    };
}(window.tuskr.addTask = window.tuskr.addTask || {}, jQuery));


