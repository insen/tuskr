window.tuskr = window.tuskr || {};


(function (AllTasks, $, undefined) {
    var dlgopts = {
        dialogClass: 'opaque',
        height: 'auto',
        width: 400,
        modal: true,
        position: ['relative'],
        autoOpen: false,
        closeOnEscape: false,
        open: function() {
            window.tuskr.addTask.init(AllTasks, $('#template-add'));
        }
    };

    AllTasks.resume = function() {
        $('.b-data').show();
    };
    
    AllTasks.suspend = function () {
        $('.b-data').hide();
    };

    AllTasks.init = function () {
        $('.b-hdr .add').click(function () {
            $('#template-add').dialog(dlgopts);
            $('#template-add').dialog('open');
            AllTasks.suspend();
        });
        
        $('.task-gp-hdr').click(function () {
            var header = $(this).closest('tr');
            var elements = $('tbody [data-group-reference=' + header.attr('id') + ']');

            elements.toggle('toggle');
            return false;
        });
    };
}(window.tuskr.AllTasks = window.tuskr.AllTasks || {}, jQuery));


$(document).ready(function () {
    window.tuskr.AllTasks.init();
});
