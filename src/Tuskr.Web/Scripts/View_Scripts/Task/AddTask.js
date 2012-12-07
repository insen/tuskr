window.tuskr = window.tuskr || {};

(function (addTask, $, undefined) {
    addTask.init = function (callee, $dialog) {
        $('#submit', $dialog).click(function (e) {
//            $('form').submit();
            e.preventDefault();
            var $this = $('form');

            $.ajax({
                url: $this.attr('action'),
                type: $this.attr('method'),
                data: $this.serialize(),
                success: function (output) {
                    // return output;
                    alert(output);
                },
                error: function() {
                    alert('Something went wrong!');
                }
            });
        });
        
        $('#close', $dialog).click(function () {
            $dialog.dialog('close');
            callee.resume();
        });
    };
}(window.tuskr.addTask = window.tuskr.addTask || {}, jQuery));


